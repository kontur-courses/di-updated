using TagsCloudVisualization.Saver;
using TagsCloudVisualization.Filter;
using TagsCloudVisualization.Reader;

namespace TagsCloudVisualization.Generator;

public class TagCloudImageGenerator(
    IImageSaver saver,
    ITextReader reader,
    IBitmapGenerator bitmapGenerator,
    IEnumerable<ITextFilter> filters)
{
    private const int MaxFontSize = 100;
    private const int MinFontSize = 8;
    private int maxWordCount;
    private int minWordCount;

    public void GenerateCloud()
    {
        var text = reader.ReadText();

        var wordsFrequency = filters
            .Aggregate(text, (word, filter) => filter.ApplyFilter(word))
            .GroupBy(w => w)
            .OrderByDescending(words => words.Count())
            .ToDictionary(words => words.Key, words => words.Count());

        minWordCount = wordsFrequency.Values.Min();
        maxWordCount = wordsFrequency.Values.Max();

        var words = wordsFrequency
            .Select(w => new TagWord(w.Key, GetFontSize(w.Value)));

        var bitmap = bitmapGenerator.GenerateBitmap(words);
        saver.SaveImageToFile(bitmap);
    }

    private int GetFontSize(int frequencyCount) =>
        MinFontSize + (MaxFontSize - MinFontSize)
        * (frequencyCount - minWordCount) / (maxWordCount - minWordCount);
}