using TagsCloudVisualization.ConsoleCommands;
using TagsCloudVisualization.FileReaders;
using TagsCloudVisualization.Layouters;
using TagsCloudVisualization.Renderers;
using TagsCloudVisualization.WordPreprocessors;

namespace TagsCloudVisualization.App;

public class ConsoleApp : IApp
{
    private readonly IWordPreprocessor wordPreprocessor;
    private readonly IFileReader fileReader;
    private readonly ICloudLayouter cloudLayouter;
    private readonly ICloudRenderer cloudRenderer;
    private readonly string inputFilePath;

    public ConsoleApp(IWordPreprocessor wordPreprocessor,
        IFileReader fileReader,
        ICloudLayouter cloudLayouter,
        ICloudRenderer cloudRenderer,
        Options options)
    {
        this.wordPreprocessor = wordPreprocessor;
        this.fileReader = fileReader;
        this.cloudLayouter = cloudLayouter;
        this.cloudRenderer = cloudRenderer;
        inputFilePath = options.InputFilePath;
    }
    
    public void Run()
    {
        var words = wordPreprocessor.ProcessWords(fileReader.Read(inputFilePath));
        cloudRenderer.Render(cloudLayouter.CreateTagsCloud(words));
    }
}