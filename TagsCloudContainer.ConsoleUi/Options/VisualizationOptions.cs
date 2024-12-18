using CommandLine;
using TagsCloudContainer.ConsoleUi.Options.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Options;

[Verb("files", HelpText = "Настройки путей файлов")]
public class VisualizationOptions : IOptions
{
    [Option('i', "input", Required = true, HelpText = "Путь к файлу текста для анализа.")]
    public string InputPath { get; set; }

    [Option('o', "output", Required = true, HelpText = "Путь к сохранению изображения.")]
    public string OutputPath { get; set; }
}