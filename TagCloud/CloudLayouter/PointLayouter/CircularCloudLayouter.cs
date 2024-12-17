using System.Drawing;
using TagCloud.CloudLayouter.Extensions;
using TagCloud.CloudLayouter.PointLayouter.Generators;

namespace TagCloud.CloudLayouter.PointLayouter;

public class CircularCloudLayouter(Point layoutCenter, IPointsGenerator pointsGenerator) : ICloudLayouter
{
    private const string FiniteGeneratorExceptionMessage =
        "В конструктор CircularCloudLayouter был передан конечный генератор точек";
    private readonly IEnumerator<Point> _pointEnumerator = pointsGenerator
        .GeneratePoints(layoutCenter)
        .GetEnumerator();
    private readonly List<Rectangle> _layoutRectangles = [];

    public CircularCloudLayouter(Point layoutCenter, double radius, double angleOffset) :
        this(layoutCenter, new FermatSpiralPointsGenerator(radius, angleOffset))
    {

    }

    public Rectangle PutNextRectangle(Size rectangleSize)
    {
        var rectangle = _pointEnumerator
            .ToIEnumerable()
            .Select(point => new Rectangle()
                .CreateRectangleWithCenter(point, rectangleSize))
            .FirstOrDefault(rectangle => !_layoutRectangles.Any(rectangle.IntersectsWith));

        if (rectangle.IsEmpty)
            throw new InvalidOperationException(FiniteGeneratorExceptionMessage);

        _layoutRectangles.Add(rectangle);
        return rectangle;
    }
}