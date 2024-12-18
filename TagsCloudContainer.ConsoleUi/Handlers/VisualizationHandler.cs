using TagsCloudContainer.ConsoleUi.Handlers.Interfaces;
using TagsCloudContainer.ConsoleUi.Options;
using TagsCloudContainer.ConsoleUi.Options.Interfaces;
using TagsCloudContainer.TagsCloudVisualization.Logic.Visualizers.Interfaces;
using TagsCloudContainer.TagsCloudVisualization.Providers.Interfaces;
using TagsCloudContainer.TextAnalyzer.Logic.Preprocessors.Interfaces;
using TagsCloudContainer.TextAnalyzer.Logic.Readers.Interfaces;
using TagsCloudContainer.TextAnalyzer.Providers.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Handlers;

public class VisualizationHandler(
    IFileTextReader fileReader,
    ITextPreprocessor textPreprocessor,
    IWordsCloudVisualizer wordsCloudVisualizer,
    IImageSettingsProvider imageSettingsProvider,
    IWordSettingsProvider wordSettingsProvider)
    : IHandlerT<VisualizationOptions>
{
    public bool TryExecute(IOptions options, out string result)
    {
        if (options is VisualizationOptions visualizationOptions)
        {
            result = Execute(visualizationOptions);
            return true;
        }

        result = string.Empty;
        return false;
    }

    public string Execute(VisualizationOptions options)
    {
        GenerateFile(options);
        return "Генерация файла";
    }

    private void GenerateFile(VisualizationOptions options)
    {
        var imageSettings = imageSettingsProvider.GetImageSettings();
        var wordSettings = wordSettingsProvider.GetWordSettings();
        var text = fileReader.ReadText(options.InputPath);
        var analyzeWords = textPreprocessor.GetWordFrequencies(text, wordSettings);
        using var image = wordsCloudVisualizer.CreateImage(imageSettings, analyzeWords);
        wordsCloudVisualizer.SaveImage(image, imageSettings, options.OutputPath);
    }
}