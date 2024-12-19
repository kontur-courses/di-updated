﻿using Autofac;
using TagsCloudConsole.Extensions;
using TagsCloudVisualization;

namespace TagsCloudConsole;

public static class Program
{
    public static void Main(string[] args)
    {
        var options = CommandLine.Parser.Default
            .ParseArguments<TagsCloudVisualizationOptions>(args)
            .Value;

        var container = new ContainerBuilder()
            .RegisterWordAnalytics()
            .RegisterWordHandlers()
            .RegisterTextReaders()
            .RegisterImageSavers(options)
            .RegisterColorFactory(options)
            .RegisterCloudLayouter(options)
            .RegisterTagLayouter(options)
            .RegisterTagVisualizer()
            .RegisterTagsCloudImageCreator()
            .Build();

        var creator = container.Resolve<TagsCloudImageCreator>();
        creator.CreateImageWithTags(options.PathToLoad);
    }
}