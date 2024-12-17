using System.Text;

namespace TagCloud.WordsReader.Readers;

public class FileReader(string path, Encoding encoding) : IWordsReader
{
    public List<string> ReadWords() 
        => File.ReadAllLines(path, encoding)
            .Select(line => line.Split(" "))
            .SelectMany(arr => arr)
            .ToList();
}