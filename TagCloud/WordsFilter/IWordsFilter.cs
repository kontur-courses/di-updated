namespace TagCloud.WordsFilter;

public interface IWordsFilter
{
    List<string> FilterWords(List<string> words);
}