using System.Drawing;
using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization.Saver;

public class ImageSaver(SaveSettings settings) : IImageSaver
{
    public string SaveImageToFile(Bitmap bitmap)
    {
        #pragma warning disable CA1416
        bitmap.Save($"{settings.Filename}.{settings.Format}", settings.ImageFormat);
        #pragma warning restore CA1416
        Console.WriteLine($"Tag cloud visualization saved to: {Path.GetFullPath(settings.Filename)}.{settings.Format}");

        return Path.GetFullPath(settings.Filename);
    }
}