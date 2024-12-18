using FluentAssertions;
using SkiaSharp;
using TagCloud.CloudLayouter;
using TagCloud.Utility;

namespace TagCloudTests;

[TestFixture]
[TestOf(typeof(CircularCloudLayouter))]
public class CircularCloudLayouterTests
{
    private CircularCloudLayouter circularCloudLayouter;

    [SetUp]
    public void Setup()
    {
        circularCloudLayouter = new CircularCloudLayouter(new SKPoint(0, 0));
    }

    [Test]
    public void PutNextRectangle_ShouldReturnRectangleAtCenter_WhenFirstInvoked()
    {
        var rectSize = Random.Shared.NextSkSize(1, int.MaxValue);
        
        var actualRect = circularCloudLayouter.PutNextRectangle(rectSize);
        
        var expectedRect = new SKRect(
            circularCloudLayouter.Center.X - rectSize.Width / 2,
                circularCloudLayouter.Center.Y - rectSize.Height / 2,
            circularCloudLayouter.Center.X + rectSize.Width / 2, 
            circularCloudLayouter.Center.Y + rectSize.Height / 2);
        
        actualRect.Should().BeEquivalentTo(expectedRect);
    }

    [Test]
    public void PutNextRectangle_ShouldReturnRectangle_WithCorrectSize()
    {
        var rectangleSize = Random.Shared.NextSkSize(1, int.MaxValue);
        
        var actualRectangle = circularCloudLayouter.PutNextRectangle(rectangleSize);
        
        actualRectangle.Size.Should().Be(rectangleSize);
    }
    
    [Test]
    public void PutNextRectangle_ShouldReturnRectangles_WithoutIntersections()
    {
        var numberOfRectangles = Random.Shared.Next(100, 300);
        
        var rectangles = Enumerable
            .Range(0, numberOfRectangles)
            .Select(_ => circularCloudLayouter.PutNextRectangle(Random.Shared.NextSkSize(10, 27)))
            .ToList();

        bool IsIntersectionBetweenRectangles(SKRect rect) => 
                    rectangles.Any(otherRect => rect != otherRect && rect.IntersectsWith(otherRect));

        rectangles.Any(IsIntersectionBetweenRectangles)
            .Should().BeFalse();
    }

    [Test]
    public void GeneratedLayout_ShouldHaveHighTightnessAndShapeOfCircularCloud()
    {
        const double eps = 0.35;
        var rectangles = PutRandomRectanglesInLayouter(Random.Shared.Next(500, 1000));
        var layoutSize = GetLayoutSize(rectangles);
        
        var diameterOfCircle = Math.Max(layoutSize.Width, layoutSize.Height);
        var areaOfCircle = Math.PI * Math.Pow(diameterOfCircle, 2) / 4;
        var areaOfRectangles = (double)rectangles
            .Select(r => r.Height * r.Width)
            .Sum();
        var areaRatio = areaOfCircle / areaOfRectangles;

        areaRatio.Should().BeApproximately(1, eps);
    }
    
    private List<SKRect> PutRandomRectanglesInLayouter(int numberOfRectangles) =>
        Enumerable
            .Range(0, numberOfRectangles)
            .Select(_ => circularCloudLayouter.PutNextRectangle(Random.Shared.NextSkSize(10, 27)))
            .ToList();

    private static SKSize GetLayoutSize(List<SKRect> rectangles)
    {
        var layoutWidth = rectangles.Max(r => r.Right) - rectangles.Min(r => r.Left);
        var layoutHeight = rectangles.Max(r => r.Top) - rectangles.Min(r => r.Bottom);
        
        return new SKSize(layoutWidth, layoutHeight);
    }
}