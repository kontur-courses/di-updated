using TagsCloudVisualization.Settings;

namespace TagsCloudVisualization.Client;

public interface IClient
{
    public SettingsManager GetSettings();
}