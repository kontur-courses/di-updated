using TagCloud.TextData;

public class CompositeFilter : ITextFilter
{
    private readonly List<ITextFilter> _filters;

    public CompositeFilter(IEnumerable<ITextFilter> filters)
    {
        _filters = [..filters];
    }

    public bool ShouldKeep(ITextData textData)
    {
        return _filters.All(filter => filter.ShouldKeep(textData));
    }
} 