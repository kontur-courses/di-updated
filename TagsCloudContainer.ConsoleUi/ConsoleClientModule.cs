using Autofac;
using TagsCloudContainer.ConsoleUi.Handlers;
using TagsCloudContainer.ConsoleUi.Handlers.Interfaces;
using TagsCloudContainer.ConsoleUi.Runner;
using TagsCloudContainer.ConsoleUi.Runner.Interfaces;

namespace TagsCloudContainer.ConsoleUi;

public class ConsoleClientModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TagsCloudContainerUi>().As<ITagsCloudContainerUi>();
        builder.RegisterType<ExitHandler>().As<IHandler>();
        builder.RegisterType<WordSettingsHandler>().As<IHandler>();
        builder.RegisterType<ImageSettingHandler>().As<IHandler>();
        builder.RegisterType<VisualizationHandler>().As<IHandler>();
    }
}