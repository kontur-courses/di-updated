namespace TagsCloudVisualization.FileReaders;

//Хочу попробовать переписать на visitor, чтобы избежать свича
public class DelegateFileReader : IFileReader
{
    public IEnumerable<string> Read(string filePath)
    {
        try
        {
            var reader = CreateReader(filePath);
            return reader.Read(filePath);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    private static IFileReader CreateReader(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("File not found", filePath);
        
        var extension = Path.GetExtension(filePath).Trim('.');
        Enum.TryParse(extension, true, out FileType fileType);
        
        return fileType switch
        {
            FileType.Txt => new TextFileReader(),
            _ => throw new NotSupportedException($"File type {fileType} is not supported.")
        };
    }
}