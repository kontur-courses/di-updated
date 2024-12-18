using TagCloud.CloudLayouter.PointLayouter.Generators;
using TagCloud.CloudLayouter.PointLayouter.Settings;
using TagCloud.CloudLayouter.PointLayouter.Settings.Generators;
using TagCloud.ImageGenerator;
using TagCloud.ImageSaver;
using TagCloud.WordsReader.Settings;

namespace TagCloudClient;

public static class SettingsFactory
{
    public static FileReaderSettings BuildFileReaderSettings(Options options)
        => new(options.Path, options.UsingEncoding);

    public static BitmapSettings BuildBitmapSettings(Options options)
        => new(options.Size, options.Font, options.BackgroundColor, options.ForegroundColor);
    
    public static FermatSpiralSettings BuildFermatSpiralSettings(Options options)
        => new(options.Radius, options.AngleOffset);

    public static PointLayouterSettings BuildPointLayouterSettings(Options options, IPointsGenerator generator)
        => new(options.Center, generator);
    
    public static WordFileReaderSettings BuildWordReaderSettings(Options options)
        => new(options.Path);

    public static CsvFileReaderSettings BuildCsvReaderSettings(Options options) 
        => new(options.Path, options.Culture);

    public static FileSaveSettings BuildFileSaveSettings(Options options)
        => new(options.ImageName, options.ImageFormat);
}