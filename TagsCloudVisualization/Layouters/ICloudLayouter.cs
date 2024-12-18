using TagsCloudVisualization.Domain;

namespace TagsCloudVisualization.Layouters;

public interface ICloudLayouter
{
    public IEnumerable<Tag> CreateTagsCloud(Dictionary<string, int> wordsCollection);
}