using TagCloud.WordsFilter;
using TagCloud.WordsReader;
using TagCloud.ImageGenerator;
namespace TagCloud;

public class CloudGenerator(
    IWordsReader reader,
    List<IWordsFilter> filters,
    BitmapGenerator imageGenerator,
    CloudGeneratorSettings settings)
{
    public string GenerateTagCloud()
        => string.Empty;
}