namespace TagCloud.TextPreparator;

public class TextPreparator
{
    private Dictionary<string, int> _wordCount = new Dictionary<string, int>();

    public Dictionary<string, int> FillDictionary(List<string> words)
    {
        foreach (var word in words)
        {
            if (!_wordCount.ContainsKey(word))
                _wordCount[word] = 1;
            else
                _wordCount[word]++;
        }
        return _wordCount;
    }
}