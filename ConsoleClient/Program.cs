using System.Drawing;
using CommandLine;
using ConsoleClient;
using Pure.DI;
using TagCloud.FileReader;
using TagCloud.Logger;
using TagCloud.SettingsProvider;
using TagCloud.TagsCloudVisualization;
using TagCloud.WordPreprocessor;
using TagCloud.WordRenderer;
using TagCloud.WordStatistics;

DI.Setup("Composition")
    .Bind<IFileReader>().To<TxtFileReader>()
    .Bind<IWordPreprocessor>().To<TagPreprocessor>()
    .Bind<IBoringWordProvider>().To<BoringWordProviderImpl>()
    .Bind<IWordDelimiterProvider>().To<WordDelimiterProviderImpl>()
    .Bind<IWordStatistics>().To<WordStatisticsImpl>()
    .Bind<IWordRenderer>().To<TagCloudWordRenderer>()
    .Bind<ICircularCloudLayouter>().To<ICircularCloudLayouter>(
        ctx =>
        {
            ctx.Inject<ISettingsProvider>(out var settingsProvider);
            return new CircularCloudLayouterImpl(new Point(250, 250), settingsProvider);
        })
    .Bind<ISettingsProvider>().To<SettingsProviderImpl>()
    .Bind<ILogger>().To<ConsoleLogger>()
    .Hint(Hint.Resolve, "Off")
    .Bind().As(Lifetime.Singleton).To<CLIClient>()
    .Root<CLIClient>("Client");

using var composition = new Composition();
var client = composition.Client;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(client.RunOptions)
    .WithNotParsed(client.HandleParseError);