using System.Drawing;
using System.Text;
using CommandLine;
using TagCloud.FileReader;
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
    private bool _isDisposed;

    public CLIClient(
        FileReaderRegistry readerRegistry,
        IWordPreprocessor wordPreprocessor,
        IWordStatistics wordStatistics,
        IWordRenderer wordRenderer)
    {
        _readerRegistry = readerRegistry;
        _wordPreprocessor = wordPreprocessor;
        _wordStatistics = wordStatistics;
        _wordRenderer = wordRenderer;
    }
    
    public void RunOptions(Options options)
    {
        Bitmap bitmap = null;
        if (options.InputFile != null!)
        {
            var extension = Path.GetExtension(options.InputFile);
            if (_readerRegistry.TryGetFileReader(extension, out var fileReader))
            {
                fileReader.OpenFile(Path.GetFullPath(options.InputFile));
                var sb = new StringBuilder();
                while (fileReader.TryGetNextLine(out var line))
                    sb.AppendLine(line);
                
                var words = _wordPreprocessor.ExtractWords(sb.ToString());
                _wordStatistics.Populate(words);
                bitmap = _wordRenderer.Render(_wordStatistics);
            }
            else
            {
                Console.WriteLine("Input file is not supported.");
            }
        }

        if (options.OutputFile != null!)
        {
            if (bitmap != null)
                bitmap.Save(options.OutputFile);
        }
    }
    
    public void HandleParseError(IEnumerable<Error> errors)
    {
        // TODO
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
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