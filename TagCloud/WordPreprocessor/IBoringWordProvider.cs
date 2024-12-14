namespace TagCloud.WordPreprocessor;

public interface IBoringWordProvider
{
    public bool IsBoring(string word);
    public void AddBoringWord(string word);
    public void AddBoringWords(IEnumerable<string> words);
}