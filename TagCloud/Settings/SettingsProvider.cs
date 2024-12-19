namespace TagCloud.Settings;

public class SettingsProvider : ISettingsProvider
{
	private Settings _settings = new();

	public Settings GetSettings() =>
		_settings;

	public void SetSettings(Settings settings) =>
		_settings = settings;
}