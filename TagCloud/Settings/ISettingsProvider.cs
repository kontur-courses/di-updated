namespace TagCloud.Settings;

public interface ISettingsProvider
{
	Settings GetSettings();
	void SetSettings(Settings settings);
}