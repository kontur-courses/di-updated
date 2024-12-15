namespace TagCloud.WordStatistics;

public class WordStatisticsImpl : IWordStatistics
{
    private readonly Dictionary<string, int> _wordCounts = new();
    private int _totalWordCount = 0;
    
    public double GetWordFrequency(string word)
    {
        return _wordCounts.TryGetValue(word, out var count)
            ? (double)count / _totalWordCount
            : 0;
    }

    public IEnumerable<string> GetWords()
    {
        return _wordCounts.Keys
            .OrderByDescending(x => _wordCounts[x]);
    }

    public void Populate(IEnumerable<string> words)
    {
        foreach (var word in words)
        {
            _wordCounts.TryAdd(word, 0);
            _wordCounts[word]++;
            _totalWordCount++;
        }
    }
}