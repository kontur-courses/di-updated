namespace TagCloud.TextPreparator;

public class TextFilter
{
    public HashSet<string> BoringWords = new HashSet<string>();

    public List<string> GetFilteredText(List<string> words)
    {
        words.RemoveAll(word => BoringWords.Contains(word));
        return words;
    }
}