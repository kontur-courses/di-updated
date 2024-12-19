namespace TagCloud.WordStatistics;

public interface IWordStatistics
{
    public double GetWordFrequency(string word);
    public IEnumerable<string> GetWords();
    public void Populate(IEnumerable<string> words);
}