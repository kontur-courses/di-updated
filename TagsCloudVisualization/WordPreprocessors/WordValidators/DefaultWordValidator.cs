using MyStemWrapper;

namespace TagsCloudVisualization.WordPreprocessors.WordValidators;

public class DefaultWordValidator : IWordValidator
{
    private readonly MyStem myStem;

    public DefaultWordValidator(MyStem myStem)
    {
        this.myStem = myStem;
    }
    
    public bool IsValid(string word)
    {
        var result = myStem.Analysis(word);
        return !(result.Contains("CONJ") || result.Contains("INTJ") || result.Contains("PART") ||
                result.Contains("PR") || result.Contains("SPRO"));
    }
}