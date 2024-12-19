using System.Drawing;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TagCloud;
using TagCloud.CloudDrawer;
using TagCloud.CloudForms;
using TagCloud.CloudLayout;

namespace TagCloudTests;

public class CircularCloudTests
{
    private CircularCloud _circularCloud;
    private static DrawerSettings _drawerSettings = new();
    private CloudDrawer _cloudDrawer = new(_drawerSettings);


    [SetUp]
    public void SetUp()
    {
        _circularCloud =
            new CircularCloud(_drawerSettings.CloudCentre);
    }

    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed) return;
        var testName = TestContext.CurrentContext.Test.Name;
        var filePath = TestContext.CurrentContext.WorkDirectory;
        var rectangles = _circularCloud.GetRectangles();
        _drawerSettings.BackgroundSize = _circularCloud.GetCloudSize();
        SaviorImages.SaveImage(_cloudDrawer.DrawRectangles(rectangles), testName, "PNG");
        Console.WriteLine($"Tag cloud visualization saved to file  {filePath}/{testName}.png");
    }

    [TestCase(-2, 3, TestName = "Negative width")]
    [TestCase(2, -3, TestName = "Negative height")]
    [TestCase(0, 0, TestName = "zero width and height")]
    [TestCase(-2, -3, TestName = "Negative weight and height")]
    public void PutNextRectangle_ShouldThrowArgumentException_WithNegativeInput(int width, int height)
    {
        Action action = () => new CircularCloud(new Point()).PutNextRectangle(new Size(width, height));

        action.Should().Throw<ArgumentException>();
    }

    [TestCase(2, 3, TestName = "positive width and height")]
    public void PutNextRectangle_ShouldNotThrowArgumentException_WithCorrectInput(int width, int height)
    {
        Action action = () => new CircularCloud(new Point()).PutNextRectangle(new Size(width, height));

        action.Should().NotThrow<ArgumentException>();
    }

    [Test]
    public void PutNextRectangle_ShouldAddNewRectangle()
    {
        var size = new Size(10, 20);
        var coordinateX = _drawerSettings.CloudCentre.X - size.Width / 2;
        var coordinateY = _drawerSettings.CloudCentre.Y - size.Height / 2;

        _circularCloud.PutNextRectangle(size);

        _circularCloud.GetRectangles().Should()
            .Contain(new Rectangle(coordinateX, coordinateY, size.Width, size.Height));
    }

    [Test]
    public void CircularCloudLayouter_RectAngelsListShouldHaveCorrectSize()
    {
        _circularCloud.PutNextRectangle(new Size(40, 20));
        _circularCloud.PutNextRectangle(new Size(20, 40));
        _circularCloud.PutNextRectangle(new Size(50, 50));

        _circularCloud.GetRectangles().Count.Should().Be(3);
    }

    [Test]
    public void CircularCloudLayouter_RectAngelsShouldNoIntersectsWithOthers()
    {
        Random rnd = new Random();
        for (int i = 0; i < 100; i++)
        {
            int width = rnd.Next(15, 40);
            int height = rnd.Next(15, 40);
            _circularCloud.PutNextRectangle(new Size(width, height));
        }
        List<Rectangle> rectangels = _circularCloud.GetRectangles();

        foreach (Rectangle rectangle in rectangels)
        {
            rectangels.Where((_, j) => j != rectangels.IndexOf(rectangle))
                .All(r => !r.IntersectsWith(rectangle))
                .Should().BeTrue();
        }
    }
    
    [Test]
    public void GetNextPointOnSpiral_ShouldReturnPointsOnSpiral()
    {
        Spiral spiral = new Spiral(_drawerSettings.CloudCentre);
        List<Point> expected =
        [
            new Point(500, 500), new Point(500, 500), new Point(499, 501), new Point(497, 500), new Point(497, 496),
            new Point(501, 495), new Point(505, 498)
        ];
        
        List<Point> actual = [];
        for (int i = 0; i < 700; i++)
        {
            var point = spiral.GetNextPoint();
            if (i % 100 == 0)
                actual.Add(point);
        }

        actual.Should().BeEquivalentTo(expected);
    }

    [Test, MaxTime(5000)]
    public void CircularCloudLayouter_ShouldWorkInTime()
    {
        Random rnd = new Random();
        for (int i = 0; i < 10000; i++)
        {
            int width = rnd.Next(1, 10);
            int height = rnd.Next(1, 10);
            _circularCloud.PutNextRectangle(new Size(width, height));
        }
    }
}