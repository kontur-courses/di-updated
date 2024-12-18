using System.Drawing;
using TagsCloudVisualization.Settings;
using TagsCloudVisualization.Tags;

namespace TagsCloudVisualization.Visualization;

public class ImageDrawer : IImageDrawer
{
    private readonly ImageSettings imageSettings;

    public ImageDrawer(ImageSettings imageSettings)
    {
        this.imageSettings = imageSettings;
    }

    public Bitmap Draw(IEnumerable<Tag> tags)
    {
        throw new NotImplementedException();
    }
}