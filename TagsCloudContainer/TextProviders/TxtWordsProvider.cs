using System.Text;

namespace TagsCloudContainer.TextProviders;

public class TxtWordsProvider(AppConfig appConfig) : IWordsProvider
{
    private readonly char[] separators = [' ', '\t', '\r', '\n'];
    
    public IEnumerable<string> GetWords()
    {
        return File.ReadAllText(appConfig.TextFilePath, Encoding.Default)
            .Split(separators)
            .Where(x => !string.IsNullOrWhiteSpace(x));
    }
}