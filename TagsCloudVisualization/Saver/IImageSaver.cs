using System.Drawing;

namespace TagsCloudVisualization.Saver;

public interface IImageSaver
{
    public string SaveImageToFile(Bitmap bitmap);
}