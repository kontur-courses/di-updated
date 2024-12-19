using TagCloud.FileReader;

namespace TagCloud.TextPreparator;

public interface ITextHandler
{
    public Dictionary<string, int> HandleText(IFileReader text, string fileName);
}