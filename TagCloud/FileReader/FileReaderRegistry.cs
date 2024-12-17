namespace TagCloud.FileReader;

public class FileReaderRegistry : IDisposable
{
    private  Dictionary<string, IFileReader> _fileReaders;
    private bool _isDisposed;

    public FileReaderRegistry(IFileReader[] fileReaders)
    {
        _fileReaders = new Dictionary<string, IFileReader>();
        foreach (var reader in fileReaders)
            _fileReaders.Add(reader.FileExtension, reader);
    }
    
    public bool TryGetFileReader(string fileExtension, out IFileReader fileReader)
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);
        return _fileReaders.TryGetValue(fileExtension, out fileReader);
    }

    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            if (disposing)
            {
                foreach (var reader in _fileReaders.Values)
                    reader.Dispose();
                _fileReaders.Clear();
            }
            _fileReaders = null;
            _isDisposed = true;
        }
    }
}