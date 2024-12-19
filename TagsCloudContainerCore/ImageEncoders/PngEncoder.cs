using SkiaSharp;

namespace TagsCloudContainerCore.ImageEncoders;

public class PngEncoder : IImageEncoder
{
    public SKData Encode(SKImage image)
    {
        return image.Encode(SKEncodedImageFormat.Png, 100);
    }
}