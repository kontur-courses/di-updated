namespace TagsCloudContainer.Interfaces;

public interface IFileReader
{
    public string[] ReadLines(string filename);
}