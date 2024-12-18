using TagsCloudContainer.Layouters;
using TagsCloudContainer.Renderers;
using TagsCloudContainer.WordsPreprocessor;
using TagsCloudContainer.TextProviders.Factory;

namespace TagsCloudContainer;

public class App(
    IRenderer render,
    ILayouter layout,
    IWordsProviderFactory wordsProviderFactory,
    IWordsPreprocessor wordsFormatter,
    AppConfig appConfig)
{
    public void Run()
    {
        appConfig.Validate();
        var wordsProvider = wordsProviderFactory.CreateProvider(appConfig.TextFilePath);
        var words = wordsFormatter.PreprocessWords(wordsProvider.GetWords());
        var histogram = CalculateWordFrequency(words);
        
        var maxCount = histogram.Values.Max();

        foreach (var (text, count) in histogram)
        {
            var fontSize = CalculateFontSize(count, maxCount);
            var stringSize = render.GetStringSize(text, fontSize);
            var position = layout.PutNextRectangle(stringSize);
            
            var word = new Word(text, fontSize, position);
            
            render.AddWord(word);
        }

        var path = Path.Combine(appConfig.OutputPath, appConfig.Filename);
        render.SaveImage(path);
    }

    private Dictionary<string, int> CalculateWordFrequency(IEnumerable<string> words)
    {
        Dictionary<string, int> histogram = new();
        var count = 0;
        
        foreach (var word in words)
        {
            if (!histogram.TryAdd(word, 1))
            {
                histogram[word]++;
            }

            count++;
        }
        
        if (count == 0)
        {
            throw new ArgumentException("Text is empty");
        }
        
        return histogram;
    }

    private int CalculateFontSize(int count, int maxCount) => 
        appConfig.MinSize + (appConfig.MaxSize - appConfig.MinSize) * (count - 1) / maxCount;
}