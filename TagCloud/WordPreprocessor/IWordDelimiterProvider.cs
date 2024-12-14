namespace TagCloud.WordPreprocessor;

public interface IWordDelimiterProvider
{
    public string[] GetDelimiters();
    public void AddDelimiter(string delimiter);
    public void AddDelimiters(string[] delimiters);
}