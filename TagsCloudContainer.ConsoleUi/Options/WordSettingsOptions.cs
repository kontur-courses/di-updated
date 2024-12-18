using CommandLine;
using TagsCloudContainer.ConsoleUi.Options.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Options;

[Verb("words", HelpText = "Настройки анализа слов")]
public class WordSettingsOptions : IOptions
{
    [Option('v', "valid", HelpText = "Валидные части речи")]
    public IEnumerable<string> ValidSpeechParts { get; set; }
}