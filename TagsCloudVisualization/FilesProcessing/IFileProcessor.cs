namespace TagsCloudVisualization;
public interface IFileProcessor
{
    IEnumerable<string> ReadWords(string filePath);
}
