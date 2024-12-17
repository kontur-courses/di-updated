using NUnit.Framework;
using FluentAssertions;
using TagsCloudVisualization.Generator;

namespace TagsCloudVisualizationTests;

[TestFixture]
public class RectangleGeneratorTest
{
    [Test]
    public void GenerateRandomRectangles_ReturnGeneratedRectanglesNumberMatchesRequested()
    {
        var rectangles = new RectangleGenerator().GenerateRandomRectangles(10).ToList();

        rectangles.Count.Should().Be(10);
    }
    
    [Test]
    public void GenerateRandomRectangles_IsRandomRectangles_RectanglesAreGeneratedRandomly()
    {
        var rectangles1 = new RectangleGenerator().GenerateRandomRectangles(10).ToList();
        var rectangles2 = new RectangleGenerator().GenerateRandomRectangles(10).ToList();

        rectangles1.Should().NotBeEquivalentTo(rectangles2);
    }
}