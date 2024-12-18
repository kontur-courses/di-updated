using TagsCloudVisualization.WordPreprocessors.WordValidators;

namespace TagsCloudVisualization.WordPreprocessors;

public class DefaultWordPreprocessor : IWordPreprocessor
{
    private IWordValidator wordValidator;

    public DefaultWordPreprocessor(IWordValidator wordValidator)
    {
        this.wordValidator = wordValidator;
    }
    
    public Dictionary<string, int> ProcessWords(IEnumerable<string> words)
    {
        return words.SelectMany(word => word.Split())
            .Where(word => !string.IsNullOrEmpty(word))
            .GroupBy(word => word.ToLower())
            .Where(group => wordValidator.IsValid(group.Key))
            .OrderByDescending(group => group.Count())
            .ToDictionary(group => group.Key, group => group.Count());
    }
}