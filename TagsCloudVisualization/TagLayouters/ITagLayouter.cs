using TagsCloudVisualization.Tags;

namespace TagsCloudVisualization.TagLayouters;

public interface ITagLayouter
{
    IEnumerable<Tag> GetTags();   
}