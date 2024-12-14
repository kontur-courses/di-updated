namespace TagCloud.WordPreprocessor;

public class BoringWordProviderImpl : IBoringWordProvider
{
    private readonly List<string> _boringWords = new();
    
    public bool IsBoring(string word)
    {
        return _boringWords.Contains(word);
    }

    public void AddBoringWord(string word)
    {
        _boringWords.Add(word);
    }

    public void AddBoringWords(IEnumerable<string> words)
    {
        _boringWords.AddRange(words);
    }
}