namespace TagsCloudVisualization.FileReaders;

public interface IFileReader
{
    public IEnumerable<string> Read(string filePath);
}