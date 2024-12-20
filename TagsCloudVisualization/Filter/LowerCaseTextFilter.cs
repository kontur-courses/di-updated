namespace TagsCloudVisualization.Filter;

public class LowerCaseTextFilter : ITextFilter
{
    public List<string> ApplyFilter(IEnumerable<string> text)
    {
        return text.Select(word => word.ToLower()).ToList();
    }
}