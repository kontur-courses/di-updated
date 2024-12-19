using TagCloud.FileReader;

namespace TagCloud.TextPreparator;

public class TextHandler : ITextHandler
{
    private Dictionary<string, int> _wordCount = new();
    private readonly ITextFilter _textFilter;

    public TextHandler(ITextFilter textFilter)
    {
        _textFilter = textFilter;
    }

    private Dictionary<string, int> GetWordsFrequency(IEnumerable<string> words)
    {
        foreach (var word in words)
        {
            if (!_wordCount.TryAdd(word, 1))
                _wordCount[word]++;
        }

        return _wordCount;
    }

    public Dictionary<string, int> HandleText(IFileReader text, string fileName)
    {
        var words = text.TryReadFile(fileName);
        var filteredWords = _textFilter.GetFilteredText(words);
        return GetWordsFrequency(filteredWords);
    }
}