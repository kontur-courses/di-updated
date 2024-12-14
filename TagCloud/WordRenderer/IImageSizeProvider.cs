using System.Drawing;

namespace TagCloud.WordRenderer;

public interface IImageSizeProvider
{
    public Size ImageSize { get; set; }
}