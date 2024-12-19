using System.Drawing;
using TagsCloudContainer.Interfaces;

namespace TagsCloudContainer;

public class CircularCloudLayouter(IPointDistributor distributor) : ICloudLayouter
{
    private readonly List<RectangleF> rectangles = [];

    public RectangleF PutNextRectangle(SizeF rectangleSize)
    {
        RectangleF rect;
        do
        {
            var point = distributor.GetNextPoint();
            rect = RectangleFExtensions.GetRectangleFWithCenterIn(point, rectangleSize);
        } while (rectangles.Any(r => r.IntersectsWith(rect)));

        rectangles.Add(rect);
        return rect;
    }
}