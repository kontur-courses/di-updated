using TagsCloudContainer.ConsoleUi.Handlers.Interfaces;
using TagsCloudContainer.ConsoleUi.Options;
using TagsCloudContainer.ConsoleUi.Options.Interfaces;
using TagsCloudContainer.TagsCloudVisualization.Providers.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Handlers;

public class ImageSettingHandler(IImageSettingsProvider imageSettingsProvider) : IHandlerT<ImageSettingsOptions>
{
    public bool TryExecute(IOptions options, out string result)
    {
        if (options is ImageSettingsOptions settingsOptions)
        {
            result = Execute(settingsOptions);
            return true;
        }
        result = string.Empty;
        return false;
    }
    
    public string Execute(ImageSettingsOptions options)
    {
        ChangeSettings(options);
        return "Настройки изображения изменены";
    }
    
    private void ChangeSettings(ImageSettingsOptions options)
    {
        var currentSettings = imageSettingsProvider.GetImageSettings();
        if (!options.BackgroundColor.Equals(currentSettings.BackgroundColor))
        {
            imageSettingsProvider.SetBackgroundColor(options.BackgroundColor);
        }
        if (!options.WordColor.Equals(currentSettings.WordColor))
        {
            imageSettingsProvider.SetWordColor(options.WordColor);
        }
        if (!options.FontFamily.Equals(currentSettings.FontFamily))
        {
            imageSettingsProvider.SetFontFamily(options.FontFamily);
        }
        if (!options.ImageFormat.Equals(currentSettings.ImageFormat))
        {
            imageSettingsProvider.SetImageFormat(options.ImageFormat);
        }
        if (!options.Height.Equals(currentSettings.Size.Height))
        {
            var newSize = currentSettings.Size with {Height = options.Height};
            imageSettingsProvider.SetSize(newSize);
        }
        if (!options.Width.Equals(currentSettings.Size.Width))
        {
            var newSize = currentSettings.Size with {Width = options.Width};
            imageSettingsProvider.SetSize(newSize);
        }
    }
}