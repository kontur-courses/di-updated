using System.Drawing.Imaging;
using Autofac;
using TagsCloudVisualization;
using TagsCloudVisualization.Di;
using TagsCloudVisualization.Visualization;

var container = DiContainer.Configure();
var cloudCreator = container.Resolve<TagCloudCreator>();

var image = cloudCreator.CreateImage();

ImageSaver.Save(image, "", "", ImageFormat.Png);

Console.WriteLine("Hello, World!");