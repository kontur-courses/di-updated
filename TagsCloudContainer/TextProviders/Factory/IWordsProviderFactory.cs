namespace TagsCloudContainer.TextProviders.Factory;

public interface IWordsProviderFactory
{
    IWordsProvider CreateProvider(string filePath);
}