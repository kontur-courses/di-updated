namespace TagCloud.WordsFilter;

public interface IWordsFilter
{
    Dictionary<string, int> WordStatistic(List<string> words);
}