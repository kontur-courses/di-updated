namespace TagCloud.TextProvider;

public abstract class BaseTextProvider //TODO:
{
    private string filepath;

    protected BaseTextProvider(string path)
    {
        filepath = path;
    }

    public string GetFromFile()
    {
        throw new NotImplementedException();
    }
}