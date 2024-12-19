namespace TagsCloudContainer.Interfaces;

public interface IWordParser
{
    public string[] PrepareWords(string[] lines);
}