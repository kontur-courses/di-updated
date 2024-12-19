using TagCloud.TextData;
using System.Collections.Generic;

public interface ITextFilter
{
    bool ShouldKeep(ITextData textData);
}

public class WordLengthFilter : ITextFilter
{
    private readonly int _minLength;
    private readonly int _maxLength;

    public WordLengthFilter(int minLength = 3, int maxLength = 20)
    {
        _minLength = minLength;
        _maxLength = maxLength;
    }

    public bool ShouldKeep(ITextData textData)
    {
        return textData.Value.Length >= _minLength && 
               textData.Value.Length <= _maxLength;
    }
}

public class PartOfSpeechFilter : ITextFilter
{
    private readonly HashSet<string> _allowedPartsOfSpeech;

    public PartOfSpeechFilter(IEnumerable<string> allowedPartsOfSpeech)
    {
        _allowedPartsOfSpeech = new HashSet<string>(allowedPartsOfSpeech);
    }

    public bool ShouldKeep(ITextData textData)
    {
        throw new NotImplementedException();
    }
} 