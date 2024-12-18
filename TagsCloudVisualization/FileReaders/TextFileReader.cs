namespace TagsCloudVisualization.FileReaders;

public class TextFileReader : IFileReader
{
    public IEnumerable<string> Read(string filePath)
    {
        return File.ReadAllLines(filePath);
    }
}