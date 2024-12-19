using CommandLine;

namespace TagsCloudConsole;

public class TagsCloudVisualizationOptions
{
    [Option('s', "pathToSave", Required = true)]
    public string PathToSave { get; set; }
    
    [Option('l', "pathToLoad", Required = true)]
    public string PathToLoad { get; set; }
    
    [Option('c', "colorName", Required = false, Default = "Black")]
    public string ColorName { get; set; }
    
    [Option('r', "radius", Required = false, Default = 1)]
    public double LayoutRadius { get; set; }
    
    [Option('a', "angleOffset", Required = false, Default = 0.05)]
    public double LayoutAngleOffset { get; set; }
    
    [Option("fontMinSize", Required = false, Default = 14)]
    public int MinFontSize { get; set; }
    
    [Option("fontMaxSize", Required = false, Default = 28)]
    public int MaxFontSize { get; set; }
    
    [Option("fontFamily", Required = true)]
    public string FontFamily { get; set; }
}