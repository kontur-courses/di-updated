namespace TagsCloudContainer.TextProviders.Factory;

public class WordsProviderFactory(AppConfig appConfig) : IWordsProviderFactory
{
    public IWordsProvider CreateProvider(string filePath)
    {
        if (string.IsNullOrEmpty(appConfig?.TextFilePath))
            throw new ArgumentNullException(nameof(appConfig.TextFilePath), "Text file path is not provided");

        if (!File.Exists(appConfig.TextFilePath))
            throw new FileNotFoundException($"The file '{appConfig.TextFilePath}' was not found");
        
        var fileExtension = Path.GetExtension(filePath)?.ToLowerInvariant();
        
        return fileExtension switch
        {
            ".docx" => new DocxWordsProvider(appConfig),
            ".txt" => new TxtWordsProvider(appConfig),
            _ => throw new InvalidOperationException($"Unsupported file type: {fileExtension}")
        };
    }
}