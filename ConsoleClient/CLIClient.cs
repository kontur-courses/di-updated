using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using CommandLine;
using TagCloud.FileReader;
using TagCloud.Logger;
using TagCloud.WordPreprocessor;
using TagCloud.WordRenderer;
using TagCloud.WordStatistics;

namespace ConsoleClient;

public class CLIClient : IDisposable
{
    private FileReaderRegistry _readerRegistry;
    private IWordPreprocessor _wordPreprocessor;
    private IWordStatistics _wordStatistics;
    private IWordRenderer _wordRenderer;
    private ILogger _logger;
    private bool _isDisposed;

    public CLIClient(
        FileReaderRegistry readerRegistry,
        IWordPreprocessor wordPreprocessor,
        IWordStatistics wordStatistics,
        IWordRenderer wordRenderer,
        ILogger logger)
    {
        _readerRegistry = readerRegistry;
        _wordPreprocessor = wordPreprocessor;
        _wordStatistics = wordStatistics;
        _wordRenderer = wordRenderer;
        _logger = logger;
    }
    
    public void RunOptions(Options options)
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);
        
        Bitmap bitmap = null;
        if (options.InputFile != null!)
        {
            if (Path.Exists(options.InputFile))
            {
                var extension = Path.GetExtension(options.InputFile);
                if (_readerRegistry.TryGetFileReader(extension, out var fileReader))
                {
                    fileReader.OpenFile(Path.GetFullPath(options.InputFile));
                    var sb = new StringBuilder();
                    while (fileReader.TryGetNextLine(out var line))
                        sb.AppendLine(line);
                    fileReader.Dispose();

                    var words = _wordPreprocessor.ExtractWords(sb.ToString());
                    _wordStatistics.Populate(words);
                    bitmap = _wordRenderer.Render(_wordStatistics);
                }
                else
                {
                    _logger.Error("Input file is not supported.");
                }
            }
            else
            {
                _logger.Error($"Could not find input file: {Path.GetFullPath(options.InputFile)}");
            }
        }

        if (options.OutputFile != null!)
        {
            if (bitmap != null)
            {
                bitmap.Save(options.OutputFile, ImageFormat.Png);
                _logger.Info($"Output file is saved to {Path.GetFullPath(options.OutputFile)}");
            }
        }
    }

    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            if (disposing)
                _readerRegistry.Dispose();
            _readerRegistry = null;
            _isDisposed = true;
        }
    }
}