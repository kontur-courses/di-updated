namespace TagsCloudContainerCore.WordsRanker;

public interface IWordsRanker
{
    public Dictionary<string, int> GetWordsRank(string[] words);
}