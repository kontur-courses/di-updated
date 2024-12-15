using CommandLine;
using TagCloud.FileReader;

namespace ConsoleClient;

public class CLIClient : IDisposable
{
    private FileReaderRegistry _readerRegistry;
    private bool _isDisposed;

    public CLIClient(FileReaderRegistry readerRegistry)
    {
        _readerRegistry = readerRegistry;
    }
    
    public void RunOptions(Options options)
    {
        if (options.InputFile != null!)
        {
            var extension = Path.GetExtension(options.InputFile);
            if (_readerRegistry.TyrGetFileReader(extension, out var fileReader))
            {
                fileReader.OpenFile(Path.GetFullPath(options.InputFile));
                while (fileReader.TryGetNextLine(out var line))
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("Input file is not supported.");
            }
        }
    }
    
    public void HandleParseError(IEnumerable<Error> errors)
    {
        
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