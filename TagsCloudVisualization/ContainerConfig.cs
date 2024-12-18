using Autofac;
using MyStemWrapper;
using TagsCloudVisualization.App;
using TagsCloudVisualization.ConsoleCommands;
using TagsCloudVisualization.Distributors;
using TagsCloudVisualization.FileReaders;
using TagsCloudVisualization.Layouters;
using TagsCloudVisualization.Renderers;
using TagsCloudVisualization.Renderers.ColorGenerators;
using TagsCloudVisualization.WordPreprocessors;
using TagsCloudVisualization.WordPreprocessors.FontCreators;
using TagsCloudVisualization.WordPreprocessors.WordValidators;

namespace TagsCloudVisualization;

public static class ContainerConfig
{
    public static IContainer Configure(Options options)
    {
        var builder = new ContainerBuilder();
        builder.RegisterInstance(options).AsSelf().SingleInstance();
        builder.RegisterType<DefaultColorGenerator>().As<IColorGenerator>().SingleInstance();
        builder.RegisterType<SpiralDistribution>().As<ICloudDistribution>();
        builder.RegisterType<DefaultRenderer>().As<ICloudRenderer>();
        builder.RegisterType<DelegateFileReader>().As<IFileReader>();
        builder.RegisterType<DefaultFontCreator>().As<IFontCreator>();
        builder.RegisterType<DefaultWordValidator>().As<IWordValidator>();
        builder.RegisterType<DefaultWordPreprocessor>().As<IWordPreprocessor>();
        builder.RegisterType<CircularCloudLayouter>().As<ICloudLayouter>();
        builder.RegisterType<ConsoleApp>().As<IApp>();

        var myStem = new MyStem
        {
            PathToMyStem = Path.GetFullPath("Utilities\\mystem.exe"),
            Parameters = "-ni"
        };
        builder.RegisterInstance(myStem).AsSelf().SingleInstance();
        
        return builder.Build();
    }
}