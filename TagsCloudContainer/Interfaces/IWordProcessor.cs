namespace TagsCloudVisualization.Interfaces;

public interface IWordProcessor
{
    IEnumerable<string> ProcessWords(IEnumerable<string> words);
}