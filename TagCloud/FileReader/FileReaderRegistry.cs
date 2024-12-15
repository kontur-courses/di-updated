namespace TagCloud.FileReader;

public class FileReaderRegistry
{
    private Dictionary<string, IFileReader> _fileReaders  = new Dictionary<string, IFileReader>();

    public void RegisterFileReader(string fileExtension,IFileReader fileReader)
    {
        _fileReaders.TryAdd(fileExtension, fileReader);
    }

    public bool TyrGetFileReader(string fileExtension, out IFileReader fileReader)
    {
        return _fileReaders.TryGetValue(fileExtension, out fileReader);
    }
}