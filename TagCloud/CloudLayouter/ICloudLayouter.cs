using SkiaSharp;

namespace TagCloud.CloudLayouter;

public interface ICloudLayouter
{
    public SKRect PutNextRectangle(SKSize rectangleSize);
}