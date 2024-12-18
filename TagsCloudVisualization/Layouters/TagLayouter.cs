using System.Drawing;
using TagsCloudVisualization.Models;

namespace TagsCloudVisualization.Layouters;

public class TagLayouter : ITagLayouter
{
    private readonly ICloudLayouter _cloudLayouter;
    private readonly int _minFontSize;
    private readonly int _maxFontSize;
    private readonly FontFamily _fontFamily;
    private int FontSizeOffset => _maxFontSize - _minFontSize;
    private readonly Graphics _graphics;
    
    public TagLayouter(ICloudLayouter cloudLayouter, int minFontSize, int maxFontSize, FontFamily fontFamily)
    {
        if (minFontSize > maxFontSize)
            throw new ArgumentException($"{nameof(minFontSize)} must be less or equal {nameof(maxFontSize)}");
        
        _cloudLayouter = cloudLayouter;
        _minFontSize = minFontSize;
        _maxFontSize = maxFontSize;
        _fontFamily = fontFamily;
        _graphics = Graphics.FromHwnd(IntPtr.Zero);
    }

    public IEnumerable<Tag> GetTags(IEnumerable<string> words)
    {
        var wordsCounts = words
            .GroupBy(x => x)
            .ToDictionary(x => x.Key, x => x.Count());
        var maxCount = wordsCounts.Max(x => x.Value);
        var minCount = wordsCounts.Min(x => x.Value);

        foreach (var (word, count) in wordsCounts)
        {
            var fontSize = GetFontSize(count, minCount, maxCount);
            yield return new Tag(
                word, 
                fontSize, 
                _fontFamily, 
                _cloudLayouter.PutNextRectangle(GetWordSize(word, fontSize)));
        }
    }

    private int GetFontSize(int count, int minWordCount, int maxWordCount) =>
        _minFontSize + (count - minWordCount) * FontSizeOffset / (maxWordCount - minWordCount);

    private Size GetWordSize(string word, int fontSize) => 
        Size.Ceiling(_graphics.MeasureString(word, new Font(_fontFamily, fontSize)));
}