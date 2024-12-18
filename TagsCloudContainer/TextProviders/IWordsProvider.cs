namespace TagsCloudContainer.TextProviders;

public interface IWordsProvider
{
    IEnumerable<string> GetWords();
}