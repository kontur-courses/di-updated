using Autofac;
using CommandLine;
using TagsCloudVisualization.App;
using TagsCloudVisualization.ConsoleCommands;

namespace TagsCloudVisualization;

public class Program
{
    static void Main(string[] args)
    {
        var options = Parser.Default.ParseArguments<Options>(args).Value;
        var container = ContainerConfig.Configure(options);
        
        using var scope = container.BeginLifetimeScope();
        scope.Resolve<IApp>().Run();
    }
}