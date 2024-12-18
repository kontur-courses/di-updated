using System.Drawing;
using System.Text.Json;
using TagCloud.json;
using TagCloud.Logger;

namespace TagCloud.SettingsProvider;

public class SettingsProviderImpl(ILogger? logger) : ISettingsProvider
{
    private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {
        Converters =
        {
            new JsonColorConverter(),
            new JsonFontFamilyConverter(),
            new JsonSizeConverter(),
            new JsonPointConverter()
        },
        WriteIndented = true
    };
    private static readonly string _settingsFile = "settings.json";
    private static readonly Settings _defaultSettings = new Settings
    {
        BackgroundColor = Color.White,
#pragma warning disable CA1416
        Font = FontFamily.GenericMonospace,
#pragma warning restore CA1416
        ImageSize = new Size(700, 700),
        MaxFontSize = 300,
        MinFontSize = 8,
        TextColor = Color.Black,
        TracingStep = 0.001f,
        AngleStep = Math.PI / 32,
        Density = 0.1f,
        CloudCenter = new Point(350, 350)
    };

    private static readonly Settings _testSettings = new Settings
    {
        BackgroundColor = Color.White,
#pragma warning disable CA1416
        Font = FontFamily.GenericMonospace,
#pragma warning restore CA1416
        ImageSize = new Size(1000, 1000),
        MaxFontSize = 300,
        MinFontSize = 8,
        TextColor = Color.Black,
        TracingStep = 0.001f,
        AngleStep = Math.PI / 32,
        Density = 0.1f,
        CloudCenter = new Point(500, 500)
    };
    
    private Settings _settings = null!;

    public static ISettingsProvider TestSettingsProvider
    {
        get
        {
            var provider = new SettingsProviderImpl(null);
            provider._settings = _testSettings;
            return provider;
        }
    }

    public Settings GetSettings()
    {
        if (_settings != null!)
            return _settings;

        try
        {
            LoadSettings();
        }
        catch (Exception e)
        {
            _settings = _defaultSettings;
            
            logger?.Warning($"Failed to load settings file: {e.Message}");
            logger?.Warning("Using default settings.");
            
            if (!Path.Exists(_settingsFile))
            {
                SaveSettings();
                logger?.Warning("Created settings.json file in your directory.");
            }
        }
        
        return _settings;
    }

    public void UpdateSettings(Settings settings)
    {
        if (settings != _settings)
        {
            _settings = settings;
            SaveSettings();
        }
    }

    private void LoadSettings()
    {
        using var reader = new StreamReader(_settingsFile);
        var json = reader.ReadToEnd();
        _settings = JsonSerializer.Deserialize<Settings>(json, _options);

        if (!_settings.TextColor.IsKnownColor)
            throw new JsonException("Unknown TextColor value");
        if (!_settings.BackgroundColor.IsKnownColor)
            throw new JsonException("Unknown BackgroundColor value");
        if (_settings.Font == null)
        {
            var names = FontFamily.Families.Select(family => family.Name).ToArray();
            throw new JsonException($"Unknown Font value. Available options are:\n {string.Join(", ", names)}");
        }
        if (_settings.MinFontSize <= 0)
            throw new JsonException("MinFontSize must be greater than zero");
        if (_settings.MaxFontSize <= 0)
            throw new JsonException("MaxFontSize must be greater than zero");
        if (_settings.ImageSize == Size.Empty)
            throw new JsonException("ImageSize contains incorrect values");
        if (_settings.CloudCenter == Point.Empty)
            throw new JsonException("CloudCenter contains incorrect values");
        if (_settings.AngleStep <= 0)
            throw new JsonException("AngleStep must be greater than zero");
        if (_settings.TracingStep <= 0)
            throw new JsonException("TracingStep must be greater than zero");
    }

    private void SaveSettings()
    {
        var json = JsonSerializer.Serialize(_settings, _options);
        using var writer = new StreamWriter(_settingsFile);
        writer.Write(json);
    }
}