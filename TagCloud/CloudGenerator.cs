using TagCloud.ImageSaver;
using TagCloud.Visualizers;
using TagCloud.WordsFilter;
using TagCloud.WordsReader;

namespace TagCloud;

public class CloudGenerator(
    IImageSaver saver,
    IWordsReader reader,
    IVisualizer visualizer,
    IEnumerable<IWordsFilter> filters)
{

}