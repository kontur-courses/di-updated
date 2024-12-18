using TagsCloudContainer.ConsoleUi.Handlers.Interfaces;
using TagsCloudContainer.ConsoleUi.Options;
using TagsCloudContainer.ConsoleUi.Options.Interfaces;
using TagsCloudContainer.TextAnalyzer.Providers.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Handlers;

public class WordSettingsHandler(IWordSettingsProvider wordSettingsProvider) : IHandlerT<WordSettingsOptions>
{
    public bool TryExecute(IOptions options, out string result)
    {
        if (options is WordSettingsOptions settingsOptions)
        {
            result = Execute(settingsOptions);
            return true;
        }

        result = string.Empty;
        return false;
    }

    public string Execute(WordSettingsOptions options)
    {
        ChangeSettings(options);
        return "Настройки изображения изменены";
    }

    private void ChangeSettings(WordSettingsOptions options)
    {
        var currentSettings = wordSettingsProvider.GetWordSettings();
        if (!options.ValidSpeechParts.SequenceEqual(currentSettings.ValidSpeechParts))
        {
            wordSettingsProvider.SetValidSpeechParts(options.ValidSpeechParts);
        }
    }
}