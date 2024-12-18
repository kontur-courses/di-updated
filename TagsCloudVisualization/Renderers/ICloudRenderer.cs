using TagsCloudVisualization.Domain;

namespace TagsCloudVisualization.Renderers;

public interface ICloudRenderer
{
    public void Render(IEnumerable<Tag> tags);
}