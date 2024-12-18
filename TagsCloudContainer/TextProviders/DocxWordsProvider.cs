using DocumentFormat.OpenXml.Packaging;

namespace TagsCloudContainer.TextProviders;

public class DocxWordsProvider(AppConfig appConfig) : IWordsProvider
{
    private readonly char[] separators = [' ', '\t', '\r', '\n'];
    
    public IEnumerable<string> GetWords()
    {
        return ReadDocxFile(appConfig.TextFilePath)
            .Split(separators)
            .Where(x => !string.IsNullOrWhiteSpace(x));
    }

    private static string ReadDocxFile(string filePath)
    {
        using var wordDoc = WordprocessingDocument.Open(filePath, false);
        var body = wordDoc.MainDocumentPart.Document.Body;
        return body.InnerText;
    }
}