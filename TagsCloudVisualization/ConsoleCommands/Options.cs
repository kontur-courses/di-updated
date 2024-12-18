using CommandLine;

namespace TagsCloudVisualization.ConsoleCommands;

public class Options
{
    [Option('i', "inputFilePath", Required = true, HelpText = "Set input file path.")]
    public string InputFilePath { get; set; }

    [Option('o', "outputFilePath", Required = true, HelpText = "Set output file path.")]
    public string OutputFilePath { get; set; }

    [Option('f', "font", Default = "Arial", HelpText = "Set font for tags cloud words.")]
    public string TagsFont { get; set; }

    [Option('h', "imageHeight", Default = 1080, HelpText = "Set output image height.")]
    public int ImageHeight { get; set; }
    
    [Option('w', "imageWidth", Default = 1920, HelpText = "Set output image width.")]
    public int ImageWidth { get; set; }

    [Option('b', "backgroundColor", Default = "Empty", 
        HelpText = "Set background color for tags cloud.")]
    public string BackgroundColor { get; set; }
}