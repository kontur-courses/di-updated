namespace TagsCloudContainer.TextAnalyzer.Logic.Readers.Interfaces;

public interface IFileTextReader
{
    public string ReadText(Stream stream);

    public string ReadText(string path);
}