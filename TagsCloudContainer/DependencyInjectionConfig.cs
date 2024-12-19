using System.Drawing;
using Autofac;
using TagsCloudVisualization;
using TagsCloudVisualization.Interfaces;

namespace TagsCloudContainer;

public static class DependencyInjectionConfig
{
    public static IContainer BuildContainer()
    {
        var builder = new ContainerBuilder();
        
        builder.RegisterType<WordProcessor>().As<IWordProcessor>()
            .WithParameter("boringWords", new[] { "and", "or", "the", "a" });
        builder.RegisterType<CircularCloudLayouter>().As<ITagCloudLayouter>();
        builder.RegisterType<CloudImageRenderer>().As<ITagCloudRenderer>();
        builder.RegisterType<TagCloudGenerator>().As<ITagCloudGenerator>();
        builder.RegisterType<SpiralGenerator>().As<IPointGenerator>()
            .WithParameter("center", new Point(500, 500));

        return builder.Build();
    }
}