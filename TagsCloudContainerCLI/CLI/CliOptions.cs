using CommandLine;

namespace TagsCloudContainerCLI.CLI;

public class CliOptions
{
    [Option('d', "demo", Required = false, HelpText = "Run the application in demo mode.")]
    public bool Demo { get; set; }

    [Option('f', "file", Required = false, HelpText = "Specify the file path.")]
    public string File { get; set; }
}