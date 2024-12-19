namespace TagCloud.TextPreparator;

public class TextFilter : ITextFilter
{
    public ISet<string> BoringWords { get; set; } = new HashSet<string>();

    public IEnumerable<string> GetFilteredText(IEnumerable<string> words)
    {
        var filteredText = words.ToList();
        filteredText.RemoveAll(word => BoringWords.Contains(word));
        return filteredText;
    }
}