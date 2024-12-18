using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization.Reader;

public class TxtTextReader(TextReaderSettings settings) : ITextReader
{
    public List<string> ReadText()
    {
        return File.ReadLines(settings.Path, settings.Encoding).ToList();
    }
}