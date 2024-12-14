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
            .Distinct()
            .Select(ProcessWord)
            .Where(word => word != null)!;
    }

    public string? ProcessWord(string word)
    {
        return boringWordProvider.IsBoring(word)
            ? word.ToLower()
            : null;
    }
}