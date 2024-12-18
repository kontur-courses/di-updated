using NUnit.Framework;
using FluentAssertions;
using TagsCloudVisualization.Draw;

namespace TagsCloudVisualizationTests;

[TestFixture]
public class RectangleDraftsmanTest
{
    private RectangleDraftsman drawer;

    [SetUp]
    public void SetUp()
    {
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