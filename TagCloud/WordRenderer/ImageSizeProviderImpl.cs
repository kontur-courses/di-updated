using System.Drawing;

namespace TagCloud.WordRenderer;

public class ImageSizeProviderImpl : IImageSizeProvider
{
    private Size _imageSize = new Size(500, 500);

    public Size ImageSize
    {
        get => _imageSize;
        set
        {
            if (value.Width <= 0 || value.Height <= 0)
                throw new ArgumentException($"Image size cannot be {value.Width}x{value.Height}");
            _imageSize = value;
        }
    }
}