using SkiaSharp;

namespace TagsCloudContainerCore.ImageEncoders;

public interface IImageEncoder
{
    SKData Encode(SKImage image);
}