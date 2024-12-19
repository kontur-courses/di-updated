namespace TagCloud.FileReader;

public interface IFileReader
{
    public List<string> TryReadFile(String filePath);
}