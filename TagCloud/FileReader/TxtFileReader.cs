namespace TagCloud.FileReader;

public class TxtFileReader : IFileReader
{
    private StreamReader _streamReader = null!;

    public string FileExtension { get => ".txt"; }
    
    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_streamReader != null!)
                _streamReader.Dispose();
            _streamReader = null!;
        }
    }

    public void OpenFile(string filePath)
    {
        if (_streamReader != null)
            throw new InvalidOperationException("File is already open");
        ArgumentNullException.ThrowIfNull(filePath);
        
        if (!Path.IsPathFullyQualified(filePath))
            throw new ArgumentException("path must be absolute");
        if (!Path.HasExtension(filePath) || !Path.GetExtension(filePath).Equals(".txt"))
            throw new ArgumentException("given path does not refer to a .txt file");
        if (!Path.Exists(filePath))
            throw new FileNotFoundException("file not found");
        
        _streamReader = new StreamReader(filePath);
    }

    public bool TryGetNextLine(out string line)
    {
        line = String.Empty;
        if (_streamReader == null)
            throw new InvalidOperationException("File is not open");
        if (_streamReader.EndOfStream)
            return false;
        
        line = _streamReader.ReadLine()!;
        return true;
    }
}