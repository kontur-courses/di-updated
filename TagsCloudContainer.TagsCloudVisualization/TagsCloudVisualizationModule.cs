using Autofac;
using TagsCloudContainer.TagsCloudVisualization.Logic.Layouters;
using TagsCloudContainer.TagsCloudVisualization.Logic.Layouters.Interfaces;
using TagsCloudContainer.TagsCloudVisualization.Logic.SizeCalculators;
using TagsCloudContainer.TagsCloudVisualization.Logic.SizeCalculators.Interfaces;
using TagsCloudContainer.TagsCloudVisualization.Logic.Visualizers;
using TagsCloudContainer.TagsCloudVisualization.Logic.Visualizers.Interfaces;
using TagsCloudContainer.TagsCloudVisualization.Providers;
using TagsCloudContainer.TagsCloudVisualization.Providers.Interfaces;

namespace TagsCloudContainer.TagsCloudVisualization;

public class TagsCloudVisualizationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CircularCloudLayouter>().As<ICircularCloudLayouter>().InstancePerDependency();
        builder.RegisterType<WordsCloudVisualizer>().As<IWordsCloudVisualizer>();
        builder.RegisterType<ImageSettingsProvider>().As<IImageSettingsProvider>().SingleInstance();
        builder.RegisterType<WeigherWordSizer>().As<IWeigherWordSizer>();
    }
}