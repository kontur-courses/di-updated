using TagCloud.Visualization;
using TagCloud.WordsFilter;
using TagCloud.WordsReader;

namespace TagCloud;

public class TagCloudGenerator(IWordsReader reader, TagCloudImageGenerator imageGenerator, 
    IEnumerable<IWordsFilter> filters)
{
    public string GenerateTagCloud()
    {
        throw new NotImplementedException();
    }
}