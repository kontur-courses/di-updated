namespace TagCloud.WordPreprocessor;

public interface IWordPreprocessor
{
    public IEnumerable<string> ExtractWords(string text);
    public string ProcessWord(string word);
    public bool IsGoodWord(string word);
}