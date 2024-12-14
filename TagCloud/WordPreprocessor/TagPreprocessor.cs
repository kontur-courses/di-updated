namespace TagCloud.WordPreprocessor;

public class TagPreprocessor(
    IBoringWordProvider boringWordProvider,
    IWordDelimiterProvider wordDelimiterProvider
    ) : IWordPreprocessor
{
    private readonly string[] _delimiters = wordDelimiterProvider.GetDelimiters();
    
    public IEnumerable<string> ExtractWords(string text)
    {
        return text.Split(_delimiters,
                StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Select(ProcessWord)
            .Where(IsGoodWord);
    }

    public string ProcessWord(string word)
    {
        return word.ToLower();
    }

    public bool IsGoodWord(string word)
    {
        return !boringWordProvider.IsBoring(word);
    }
}