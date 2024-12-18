using Autofac;
using CommandLine;
using TagCloud;
using TagCloud.CloudLayouter;
using TagCloud.CloudLayouter.PointLayouter;
using TagCloud.CloudLayouter.PointLayouter.Generators;
using TagCloud.ImageGenerator;
using TagCloud.ImageSaver;
using TagCloud.WordsFilter;
using TagCloud.WordsReader;
using TagCloud.WordsReader.Readers;

namespace TagCloudClient;

internal static class Program
{
    public static void Main(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args)
            .WithParsed(settings =>
            {
                var container = BuildContainer(settings);
                var generator = container.Resolve<CloudGenerator>();
                Console.WriteLine("File saved in " + generator.GenerateTagCloud());
            });
    }

    private static IContainer BuildContainer(Options settings)
    {
        var builder = new ContainerBuilder();

        RegisterSettings(builder, settings);
        RegisterLayouters(builder, settings);
        RegisterWordsReaders(builder, settings);
        RegisterWordsFilters(builder, settings);

        builder.RegisterType<CloudGenerator>().AsSelf();
        builder.RegisterType<BitmapGenerator>().AsSelf();
        builder.RegisterType<BitmapFileSaver>().As<IImageSaver>();

        return builder.Build();
    }

    private static void RegisterSettings(ContainerBuilder builder, Options settings)
    {
        builder.RegisterInstance(SettingsFactory.BuildBitmapSettings(settings)).AsSelf();
        builder.RegisterInstance(SettingsFactory.BuildFileSaveSettings(settings)).AsSelf();
        builder.RegisterInstance(SettingsFactory.BuildCsvReaderSettings(settings)).AsSelf();
        builder.RegisterInstance(SettingsFactory.BuildWordReaderSettings(settings)).AsSelf();
        builder.RegisterInstance(SettingsFactory.BuildFileReaderSettings(settings)).AsSelf();
        builder.RegisterInstance(SettingsFactory.BuildFermatSpiralSettings(settings)).AsSelf();
        builder.Register(context => SettingsFactory.BuildPointLayouterSettings(
            settings, context.Resolve<IPointsGenerator>())).AsSelf();
    }

    private static void RegisterWordsReaders(ContainerBuilder builder, Options settings)
    {
        builder
            .RegisterType<FileReader>().As<IWordsReader>()
            .OnlyIf(_ => Path.GetExtension(settings.Path) == ".txt");

        builder
            .RegisterType<CsvFileReader>().As<IWordsReader>()
            .OnlyIf(_ => Path.GetExtension(settings.Path) == ".csv");

        builder
            .RegisterType<WordFileReader>().As<IWordsReader>()
            .OnlyIf(_ => Path.GetExtension(settings.Path) == ".docx");
    }

    private static void RegisterWordsFilters(ContainerBuilder builder, Options settings)
    {
        builder.RegisterType<LowercaseFilter>().As<IWordsFilter>();
        builder.RegisterType<BoringWordsFilter>().As<IWordsFilter>();
    }

    private static void RegisterLayouters(ContainerBuilder builder, Options settings)
    {
        builder
            .RegisterType<FermatSpiralPointsGenerator>().As<IPointsGenerator>();

        builder.RegisterType<CircularCloudLayouter>().As<ICloudLayouter>();
    }
}