using TagCloud.FileReader;
using TagCloud.Logger;

namespace TagCloud.WordPreprocessor;

public class WordDelimiterProviderImpl : IWordDelimiterProvider
{
    private static readonly string _delimitersFilePath = "delimiters.txt";
    
    private readonly List<string> _delimiters;
    private readonly ILogger _logger;
    private readonly FileReaderRegistry _fileReaderRegistry;

    public WordDelimiterProviderImpl(FileReaderRegistry fileReaderRegistry, ILogger logger)
    {
        _fileReaderRegistry = fileReaderRegistry;
        _logger = logger;
        _delimiters = new List<string>();
        _delimiters.AddRange(new []{ "\n", "\t", "\r", " " });
    }
    
    public string[] GetDelimiters()
    {
        if (!Path.Exists(_delimitersFilePath))
        {
            _logger.Info($"Could not find delimiters.txt file at: {Path.GetFullPath(_delimitersFilePath)}");
            _logger.Info("Using only default word delimiters.");
            return _delimiters.ToArray();
        }
        
        if (_fileReaderRegistry.TryGetFileReader(".txt", out var fileReader))
        {
            _logger.Info("Detected delimiters.txt file.");
            fileReader.OpenFile(Path.GetFullPath(_delimitersFilePath));
            while (fileReader.TryGetNextLine(out var line))
                _delimiters.Add(line);
            fileReader.Dispose();
        }
        
        return _delimiters.ToArray();
    }

    public void AddDelimiter(string delimiter)
    {
        _delimiters.Add(delimiter);
    }

    public void AddDelimiters(string[] delimiters)
    {
        _delimiters.AddRange(delimiters);
    }
}