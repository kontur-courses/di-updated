using System.Drawing;
using TagsCloudVisualization.ConsoleCommands;

namespace TagsCloudVisualization.WordPreprocessors.FontCreators;

public class DefaultFontCreator : IFontCreator
{
    private readonly string fontName;

    public DefaultFontCreator(Options options)
        => fontName = options.TagsFont;
    
    public Font CreateFont(int wordCount)
    {
        return new Font(fontName, wordCount);
    }
}