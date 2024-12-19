namespace TagCloud.WordPreprocessor;

public interface IWordPreprocessor
{
    public IEnumerable<string> ExtractWords(string text);
}