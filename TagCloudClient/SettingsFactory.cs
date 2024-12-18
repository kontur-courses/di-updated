using TagCloud.WordsReader.Settings;

namespace TagCloudClient;

public static class SettingsFactory
{
    public static FileReaderSettings BuildFileReaderSettings(Options options)
        => new(options.Path, options.UsingEncoding);
}