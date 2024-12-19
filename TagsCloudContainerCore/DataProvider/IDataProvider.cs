namespace TagsCloudContainerCore.DataProvider;

public interface IDataProvider
{
    public IEnumerable<string> GetData(string filePath);
}