namespace TagsCloudVisualization.Filter;

public interface ITextFilter
{
    public List<string> ApplyFilter(IEnumerable<string> text);
}