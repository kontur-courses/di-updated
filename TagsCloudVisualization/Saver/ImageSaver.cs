using System.Drawing.Imaging;
using TagsCloudVisualization.Draw;

namespace TagsCloudVisualization.Saver;

public class ImageSaver
{
    public void SaveImageToFile(IRectangleDraftsman rectangleDraftsman, string filename)
    {
        #pragma warning disable CA1416
        rectangleDraftsman.Bitmap.Save(filename, ImageFormat.Png);
        #pragma warning restore CA1416
        Console.WriteLine($"Tag cloud visualization saved to: {Path.GetFullPath(filename)}");
    }
}