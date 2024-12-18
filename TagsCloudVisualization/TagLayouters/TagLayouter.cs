using TagsCloudVisualization.CircularCloudLayouters;
using TagsCloudVisualization.Tags;
using TagsCloudVisualization.TextHandlers;

namespace TagsCloudVisualization.TagLayouters;

public class TagLayouter : ITagLayouter
{
    private readonly ICircularCloudLayouter circularCloudLayouter;
    private readonly ITextHandler textHandler;

    public TagLayouter(ICircularCloudLayouter circularCloudLayouter, ITextHandler textHandler)
    {
        this.textHandler = textHandler;
        this.circularCloudLayouter = circularCloudLayouter;
    }

    public IEnumerable<Tag> GetTags()
    {
        throw new NotImplementedException();
    }
}