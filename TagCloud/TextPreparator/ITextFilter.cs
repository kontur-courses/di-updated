namespace TagCloud.TextPreparator;

public interface ITextFilter
{
    public ISet<string> BoringWords { get; set; }
    public IEnumerable<string> GetFilteredText(IEnumerable<string> words);
}