using System.Drawing;

namespace TagCloud.WordRenderer;

public interface IWordRenderSizeProvider
{
    public Size GetWordRenderSize(double frequency);
}