using System.Drawing;

namespace TagsCloudVisualization.Interfaces;

public interface ITagCloudRenderer
{
    void Render(IEnumerable<Tag> tags, string outputFilePath, Size imageSize);
}