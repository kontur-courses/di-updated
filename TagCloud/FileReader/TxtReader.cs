namespace TagCloud.FileReader;

public class TxtReader : IFileReader
{
    public List<string> TryReadFile(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException();

        return File.ReadLines(filePath)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToList();
    }
}