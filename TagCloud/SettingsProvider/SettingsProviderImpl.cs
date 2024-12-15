using System.Drawing;
using System.Text.Json;
using TagCloud.Logger;

namespace TagCloud.SettingsProvider;

public class SettingsProviderImpl(ILogger logger) : ISettingsProvider
{
    private static readonly string _settingsFile = "settings.json";
    private static readonly Settings _defaultSettings = new Settings
    {
        BackgroundColor = Color.White,
#pragma warning disable CA1416
        Font = FontFamily.GenericMonospace,
#pragma warning restore CA1416
        ImageSize = new Size(500, 500),
        MaxFontSize = 70,
        MinFontSize = 8,
        TextColor = Color.Black
    };
    
    private Settings _settings = null!;
    
    public Settings GetSettings()
    {
        if (_settings != null!)
            return _settings;

        try
        {
            using var reader = new StreamReader(_settingsFile);
            var json = reader.ReadToEnd();
            _settings = JsonSerializer.Deserialize<Settings>(json);
        }
        catch (Exception e)
        {
            _settings = _defaultSettings;
            logger.Warning($"Failed to load settings file: {e.Message}");
        }
        
        return _settings;
    }

    public void UpdateSettings(Settings settings)
    {
        if (settings != _settings)
        {
            _settings = settings;
            var json = JsonSerializer.Serialize(_settings);
            using var writer = new StreamWriter(_settingsFile);
            writer.Write(json);
        }
    }
}