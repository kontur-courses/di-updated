namespace TagsCloudVisualization.WordPreprocessors;

public interface IWordPreprocessor
{
    public Dictionary<string, int> ProcessWords(IEnumerable<string> words);
}