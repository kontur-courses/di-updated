using System.Drawing;
using System.Drawing.Imaging;
using TagsCloudContainer.TagsCloudVisualization.Models.Settings;
using TagsCloudContainer.TagsCloudVisualization.Providers.Interfaces;

namespace TagsCloudContainer.TagsCloudVisualization.Providers;

public class ImageSettingsProvider : IImageSettingsProvider
{
    private ImageSettings imageSettings = new();

    public ImageSettings GetImageSettings() =>
        imageSettings;

    public void SetSize(Size size) =>
        imageSettings = imageSettings with {Size = size};

    public void SetImageFormat(ImageFormat imageFormat) =>
        imageSettings = imageSettings with {ImageFormat = imageFormat};

    public void SetBackgroundColor(Color backgroundColor) =>
        imageSettings = imageSettings with {BackgroundColor = backgroundColor};

    public void SetWordColor(Color wordColor) =>
        imageSettings = imageSettings with {WordColor = wordColor};

    public void SetFontFamily(FontFamily fontFamily) =>
        imageSettings = imageSettings with {FontFamily = fontFamily};
}