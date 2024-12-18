using TagsCloudVisualization.FileReaders;

namespace TagsCloudVisualization.TextHandlers;

public class TextHandler : ITextHandler
{
    private readonly IFileReader fileReader;

    public TextHandler(IFileReader fileReader)
    {
        this.fileReader = fileReader;
    }

    public Dictionary<string, int> HandleText()
    {
        throw new NotImplementedException();
    }
}