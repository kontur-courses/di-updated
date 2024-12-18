namespace TagCloud.WordsFilter;

public interface IWordsFilter
{
    // Applying filter on list of words
    List<string> ApplyFilter(List<string> words);
}