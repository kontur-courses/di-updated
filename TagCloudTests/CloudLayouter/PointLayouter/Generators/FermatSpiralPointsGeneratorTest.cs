using System.Drawing;
using FluentAssertions;
using TagCloud.CloudLayouter.Extensions;
using TagCloud.CloudLayouter.PointLayouter.Generators;

namespace TagCloudTests.CloudLayouter.PointLayouter.Generators;

[TestFixture]
[TestOf(typeof(FermatSpiralPointsGenerator))]
public class FermatSpiralPointsGeneratorTest
{
    [Test]
    public void ToIEnumerable_ShouldReturnExpectedEnumerable()
    {
        const int elementsNumber = 1000;
        var centerPoint = new Point(0, 0);
        var expectedEnumerable = new FermatSpiralPointsGenerator(1, 0.5)
            .GeneratePoints(centerPoint);
        var enumerable = expectedEnumerable.Take(elementsNumber).ToList();
        
        using var enumerator = enumerable.GetEnumerator();
        var actualEnumerable = enumerator.ToIEnumerable();

        actualEnumerable.Take(elementsNumber).Should()
            .BeEquivalentTo(enumerable.Take(elementsNumber));
    }

    [Test]
    public void ToIEnumerable_ShouldContinueEnumeration()
    {
        const int elementsNumber = 10;

        var startEnumerable = Enumerable.Range(0, elementsNumber);
        using var movedEnumerator = startEnumerable.GetEnumerator();
        movedEnumerator.MoveNext();
        var actualEnumerable = movedEnumerator.ToIEnumerable();
        var expectedEnumerable = Enumerable.Range(1, elementsNumber - 1);

        actualEnumerable.Should().BeEquivalentTo(expectedEnumerable);

    }
}