using System.Drawing;
using TagsCloudVisualization.Tags;

namespace TagsCloudVisualization.Visualization;

public interface IImageDrawer
{
    Bitmap Draw(IEnumerable<Tag> tags);
}