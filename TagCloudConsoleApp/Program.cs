using Autofac;
using System.Drawing;
using TagsCloudVisualization.Draw;
using TagsCloudVisualization.Saver;
using TagsCloudVisualization.CloudLayouter;
using TagsCloudVisualization.FileParser;
using TagsCloudVisualization.Generator;

var builder = new ContainerBuilder();
RegisterServices(builder);
builder.Build();


var center = new Point(0, 0);
var layouter = new CircularCloudLayouter(center, new RectangleGenerator(), 1001);
var drawer = new RectangleDraftsman(1500, 1500);
const string filename = "CloudRectangles1001.png";
drawer.CreateImage(layouter.Rectangles);
var saver = new ImageSaver();
saver.SaveImageToFile(drawer, filename);
return;

void RegisterServices(ContainerBuilder containerBuilder)
{
    containerBuilder.RegisterType<CircularCloudLayouter>().As<ICloudLayouter>().SingleInstance();
    containerBuilder.RegisterType<RectangleDraftsman>().As<IRectangleDraftsman>().SingleInstance();
    containerBuilder.RegisterType<RectangleGenerator>().As<IRectangleGenerator>().SingleInstance();
    containerBuilder.RegisterType<ImageSaver>().As<IImageSaver>().SingleInstance();
    containerBuilder.RegisterType<FileParser>().As<IFileParser>().SingleInstance();
}