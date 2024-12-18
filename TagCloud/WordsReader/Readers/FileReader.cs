using System.Text;
using TagCloud.WordsReader.Settings;

namespace TagCloud.WordsReader.Readers;

public class FileReader(FileReaderSettings settings) : IWordsReader
{
    public List<string> ReadWords() 
        => File.ReadAllLines(settings.FilePath, settings.Encoding)
            .Select(line => line.Split(" "))
            .SelectMany(arr => arr)
            .ToList();
}