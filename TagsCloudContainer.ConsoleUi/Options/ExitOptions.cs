using CommandLine;
using TagsCloudContainer.ConsoleUi.Options.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Options;

[Verb("exit", HelpText = "Выйти")]
public class ExitOptions : IOptions
{
}