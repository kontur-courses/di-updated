using TagsCloudVisualization.TagLayouters;
using TagsCloudVisualization.Visualization;

namespace TagsCloudVisualization;

public class TagCloudCreator
{
    private readonly ITagLayouter tagLayouter;
    private readonly IImageDrawer imageDrawer;

    public TagCloudCreator(ITagLayouter tagLayouter, IImageDrawer imageDrawer)
    {
        this.tagLayouter = tagLayouter;
        this.imageDrawer = imageDrawer;
    }

    public void CreateImage()
    {
        throw new NotImplementedException();
    }
}