using System.Drawing;
using TagsCloudVisualization;
using TagsCloudVisualization.Interfaces;

namespace TagsCloudContainer;

public class TagCloudGenerator : ITagCloudGenerator
{
    private readonly IWordProcessor _wordProcessor;
    private readonly ITagCloudLayouter _layouter;
    private readonly ITagCloudRenderer _renderer;

    public TagCloudGenerator(IWordProcessor wordProcessor, ITagCloudLayouter layouter, ITagCloudRenderer renderer)
    {
        _wordProcessor = wordProcessor;
        _layouter = layouter;
        _renderer = renderer;
    }

    public void GenerateCloud(string inputFilePath, string outputFilePath, Size imageSize)
    {
        var words = File.ReadAllLines(inputFilePath);
        var processedWords = _wordProcessor.ProcessWords(words);

        var wordFrequencies = processedWords
            .GroupBy(w => w)
            .ToDictionary(g => g.Key, g => g.Count());

        var tags = wordFrequencies
            .OrderByDescending(pair => pair.Value)
            .Select(pair => new Tag(pair.Key, pair.Value))
            .ToList();

        foreach (var tag in tags)
        {
            var size = new Size(tag.Frequency * 10, tag.Frequency * 10);
            var rectangle = _layouter.PutNextRectangle(size);
            tag.Rectangle = rectangle;
        }

        _renderer.Render(tags, outputFilePath, imageSize);
    }
}