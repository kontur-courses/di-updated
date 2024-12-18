namespace TagsCloudVisualization.FileReaders;

public interface IFileReader
{
    bool CanRead(string pathToFile);

    string Read(string pathToFile);
}