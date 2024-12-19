using System.Drawing;
using System.Drawing.Imaging;
using TagsCloudVisualization.Interfaces;

namespace TagsCloudVisualization;

public class CloudImageRenderer: ITagCloudRenderer
{
    public void Render(IEnumerable<Tag> tags, string outputFilePath, Size imageSize)
    {
        throw new NotImplementedException();
    }
    
    private static Color RandomColor()
    {
        var random = new Random();
        return Color.FromArgb(random.Next(128, 255), random.Next(128, 255), random.Next(128, 255));
    }
}