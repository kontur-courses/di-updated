using System.Drawing;

namespace TagsCloudVisualization.WordPreprocessors.FontCreators;

public interface IFontCreator
{
    public Font CreateFont(int wordCount);
}