using System.Drawing;
using NUnit.Framework;
using FluentAssertions;
using TagsCloudVisualization.CloudLayouter;
using TagsCloudVisualization.Draw;
using TagsCloudVisualization.Extension;
using TagsCloudVisualization.Generator;

namespace TagsCloudVisualizationTests;

[TestFixture]
public class RectangleDraftsmanTest
{
    private Point center;
    private CircularCloudLayouter cloudLayouter;
    private IEnumerable<Rectangle> rectangles;
    private RectangleDraftsman drawer;

    [SetUp]
    public void SetUp()
    {
        center = new Point(0, 0);
        cloudLayouter = new CircularCloudLayouter(center, new RectangleGenerator(), 10);
        drawer = new RectangleDraftsman(1500, 1500);
    }

    [Test]
    public void CreateImage_WhenListOfRectanglesIsNull_ThrowsArgumentException()
    {
        var action = () => drawer.CreateImage(null);
        action.Should().Throw<NullReferenceException>();
    }

    [TestCase(-1, 1)]
    [TestCase(1, -1)]
    [TestCase(1, 0)]
    [TestCase(0, 1)]
    public void Constructor_OnInvalidArguments_ThrowsArgumentException(int width, int height)
    {
        Action action = () => new RectangleDraftsman(width, height);
        action.Should().Throw<ArgumentException>();
    }
}