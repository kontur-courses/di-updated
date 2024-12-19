using SkiaSharp;

namespace TagsCloudContainerCore.Layouter;

public interface ICircularCloudLayouter
{
    SKRect PutNextRectangle(SKSize rectangleSize);
    void SetCenter(SKPoint center);
    SKRect[] GetRectangles();
}