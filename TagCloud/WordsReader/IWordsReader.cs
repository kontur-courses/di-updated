namespace TagCloud.WordsReader;

public interface IWordsReader
{
    // Reads words from filestream
    List<string> ReadWords();
}