using Microsoft.Extensions.Logging;

namespace TagsCloudContainerCore.DataProvider;

public class FileDataProvider : IDataProvider
{
    private readonly ILogger<IDataProvider> _logger;

    public FileDataProvider(ILogger<IDataProvider> logger)
    {
        _logger = logger;
    }

    public IEnumerable<string> GetData(string filePath)
    {
        _logger.LogInformation("Opening file {file}", filePath);
        using var reader = new StreamReader(filePath);
        while (!reader.EndOfStream) yield return reader.ReadLine();
        _logger.LogInformation("Finished reading file");
    }
}