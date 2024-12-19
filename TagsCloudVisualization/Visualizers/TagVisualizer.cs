using System.Drawing;
using TagsCloudVisualization.ColorFactories;
using TagsCloudVisualization.Models;

namespace TagsCloudVisualization.Visualizers;

public class TagVisualizer(IColorFactory colorFactory) : ITagVisualizer
{
    public Bitmap Visualize(IEnumerable<Tag> tags)
    {
        throw new NotImplementedException();
    }
}