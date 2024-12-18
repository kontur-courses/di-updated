namespace TagCloud.FileReader;

public interface IFileReader
{
    public bool TryReadFile(String filePath);
}