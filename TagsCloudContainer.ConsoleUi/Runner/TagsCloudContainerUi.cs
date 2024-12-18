using System.Collections.Frozen;
using CommandLine;
using TagsCloudContainer.ConsoleUi.Handlers.Interfaces;
using TagsCloudContainer.ConsoleUi.Options;
using TagsCloudContainer.ConsoleUi.Options.Interfaces;
using TagsCloudContainer.ConsoleUi.Runner.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Runner;

public class TagsCloudContainerUi : ITagsCloudContainerUi
{
    private readonly IReadOnlyCollection<IHandler> handlers;

    private readonly IReadOnlySet<Type> optionsTypes = new HashSet<Type>()
    {
        typeof(ExitOptions),
        typeof(WordSettingsOptions),
        typeof(ImageSettingsOptions),
        typeof(VisualizationOptions),
    };

    public TagsCloudContainerUi(IEnumerable<IHandler> handlers)
    {
        this.handlers = handlers.ToFrozenSet();
    }

    public void Run()
    {
        var types = optionsTypes.ToArray();
        while (true)
        {
            var input = Console.ReadLine();
            var args = input?.Split(' ', StringSplitOptions.RemoveEmptyEntries) ?? [];
            Parser.Default.ParseArguments(args, types)
                .WithParsed<IOptions>(Handle);
        }
    }

    private void Handle(IOptions options)
    {
        var message = string.Empty;
        foreach (var handler in handlers)
        {
            var hasResult = handler.TryExecute(options, out message);
            if (hasResult)
            {
                break;
            }
        }

        Console.WriteLine(message);
    }
}