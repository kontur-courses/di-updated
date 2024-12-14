namespace TagCloud.WordPreprocessor;

public class WordDelimiterProviderImpl : IWordDelimiterProvider
{
    private readonly List<string> _delimiters = new();
    
    public string[] GetDelimiters()
    {
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