using FakeItEasy;
using NUnit.Framework;
using FluentAssertions;
using System.Runtime.InteropServices;
using TagsCloudVisualization.Draw;
using TagsCloudVisualization.Saver;
using TagsCloudVisualization.Settings;
using TagsCloudVisualization.CloudLayouter;
using TagsCloudVisualization.Generator;

namespace TagsCloudVisualizationTests;

[TestFixture]
public class ImageSaverTest
{
    private CircularCloudLayouter cloudLayouter;
    private RectangleDraftsman drawer;
    private ImageSaver imageSaver;

    [SetUp]
    public void SetUp()
    {
        var mockPositionGenerator = A.Fake<IPositionGenerator>();
        cloudLayouter = new CircularCloudLayouter(mockPositionGenerator);
        drawer = new RectangleDraftsman(1500, 1500);
    }

    [TestCase(null)]
    public void CreateImage_OnInvalidParameters_ThrowsArgumentException(string filename)
    {
        imageSaver = new ImageSaver(new SaveSettings(filename, "png"));
        drawer.CreateImage(cloudLayouter.Rectangles);
        var action = () => imageSaver.SaveImageToFile(drawer.Bitmap);
        action.Should().Throw<ArgumentException>();
    }

    [TestCase("12\\")]
    [TestCase("@#$\\")]
    public void CreateImage_OnInvalidParameters_ThrowsDirectoryNotFoundException(string filename)
    {
        imageSaver = new ImageSaver(new SaveSettings(filename, "png"));
        drawer.CreateImage(cloudLayouter.Rectangles);
        var action = () => imageSaver.SaveImageToFile(drawer.Bitmap);
        action.Should().Throw<DirectoryNotFoundException>();
    }

    [TestCase("abc|123")]
    [TestCase("123|abc")]
    [TestCase("123\n")]
    [TestCase("123\r")]
    public void CreateImage_OnInvalidParameters_ThrowsExternalException(string filename)
    {
        imageSaver = new ImageSaver(new SaveSettings(filename, "png"));
        drawer.CreateImage(cloudLayouter.Rectangles);
        var action = () => imageSaver.SaveImageToFile(drawer.Bitmap);
        action.Should().Throw<ExternalException>();
    }
}