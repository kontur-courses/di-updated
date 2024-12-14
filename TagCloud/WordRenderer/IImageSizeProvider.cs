using System.Drawing;

namespace TagCloud.WordRenderer;

public interface IImageSizeProvider
{
    public Size GetImageSize();
}