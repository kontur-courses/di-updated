using TagCloud.CloudLayouter.PointLayouter.Generators;
using TagCloud.CloudLayouter.PointLayouter.Settings;
using TagCloud.CloudLayouter.PointLayouter.Settings.Generators;
using TagCloud.ImageGenerator;
using TagCloud.WordsReader.Settings;

namespace TagCloudClient;

public static class SettingsFactory
{
    public static FileReaderSettings BuildFileReaderSettings(Options options)
        => new(options.Path, options.UsingEncoding);

    public static BitmapSettings BuildBitmapSettings(Options options)
        => new(options.Size, options.Font, options.ImageName, options.BackgroundColor, options.WordsColor);
    
    public static FermatSpiralSettings BuildFermatSpiralSettings(Options options)
        => new(options.Radius, options.AngleOffset);

    public static PointLayouterSettings BuildPointLayouterSettings(Options options, IPointsGenerator generator)
        => new(options.Center, generator);
}