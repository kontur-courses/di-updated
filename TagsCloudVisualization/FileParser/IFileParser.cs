namespace TagsCloudVisualization.FileParser;

public interface IFileParser
{
    public IEnumerable<string> Parse(string path);
}