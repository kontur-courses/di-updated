using Autofac;
using TagsCloudVisualization.Draw;
using TagsCloudVisualization.Saver;
using TagsCloudVisualization.Client;
using TagsCloudVisualization.Reader;
using TagsCloudVisualization.Filter;
using TagsCloudVisualization.Settings;
using TagsCloudVisualization.Generator;
using TagsCloudVisualization.CloudLayouter;

var client = new Client(args);
var settings = client.GetSettings();
var builder = new ContainerBuilder();

RegisterServices(builder);
RegisterSettings(builder, settings);

var build = builder.Build();
var tagCloudImageGenerator = build.Resolve<TagCloudImageGenerator>();
tagCloudImageGenerator.GenerateCloud();

return;

void RegisterServices(ContainerBuilder containerBuilder)
{
    containerBuilder.RegisterType<SpiralPositionGenerator>().As<IPositionGenerator>().SingleInstance();
    containerBuilder.RegisterType<RectangleDraftsman>().As<IRectangleDraftsman>().SingleInstance();
    containerBuilder.RegisterType<CircularCloudLayouter>().As<ICloudLayouter>().SingleInstance();
    containerBuilder.RegisterType<BitmapGenerator>().As<IBitmapGenerator>().SingleInstance();
    containerBuilder.RegisterType<LowerCaseTextFilter>().As<ITextFilter>().SingleInstance();
    containerBuilder.RegisterType<TxtTextReader>().As<ITextReader>().SingleInstance();
    containerBuilder.RegisterType<ImageSaver>().As<IImageSaver>().SingleInstance();
    containerBuilder.RegisterType<TagCloudImageGenerator>();
    //containerBuilder.RegisterType<BoringWordsTextFilter>().As<ITextFilter>().SingleInstance();
}

void RegisterSettings(ContainerBuilder containerBuilder, SettingsManager settingsManager)
{
    containerBuilder.RegisterInstance(settingsManager.SaveSettings);
    containerBuilder.RegisterInstance(settingsManager.TextReaderSettings);
    containerBuilder.RegisterInstance(settingsManager.BitmapGeneratorSettings);
    containerBuilder.RegisterInstance(settingsManager.SpiralGeneratorSettings);
}