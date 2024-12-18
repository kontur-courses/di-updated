using System.Drawing;
using System.Drawing.Imaging;
using TagsCloudContainer.TagsCloudVisualization.Models.Settings;

namespace TagsCloudContainer.TagsCloudVisualization.Providers.Interfaces;

public interface IImageSettingsProvider
{
    public ImageSettings GetImageSettings();
    public void SetSize(Size size);
    public void SetImageFormat(ImageFormat imageFormat);
    public void SetBackgroundColor(Color backgroundColor);
    public void SetWordColor(Color wordColor);
    public void SetFontFamily(FontFamily fontFamily);
}