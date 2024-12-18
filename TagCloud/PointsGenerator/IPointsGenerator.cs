using SkiaSharp;

namespace TagCloud.PointsGenerator;

public interface IPointsGenerator
{
    public SKPoint GetNextPoint();
}