using CommandLine;
using ConsoleClient;
using Pure.DI;
using TagCloud.FileReader;

DI.Setup("Composition")
    .Bind<IFileReader>().To<TxtFileReader>()
    .Bind().As(Lifetime.Singleton).To<CLIClient>()
    .Root<CLIClient>("Client");

using var composition = new Composition();
var client = composition.Client;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(client.RunOptions)
    .WithNotParsed(client.HandleParseError);