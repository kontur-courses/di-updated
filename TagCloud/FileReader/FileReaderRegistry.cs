namespace TagCloud.FileReader;

public static class FileReaderRegistry
{
    public static Dictionary<string, IFileReader> FileReaders { get; } = new Dictionary<string, IFileReader>();

    public static void RegisterFileReader(string fileExtension,IFileReader fileReader)
    {
        FileReaders.Add(fileExtension, fileReader);
    }
}