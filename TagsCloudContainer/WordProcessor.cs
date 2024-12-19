using TagsCloudVisualization.Interfaces;

namespace TagsCloudContainer;

public class WordProcessor(IEnumerable<string> boringWords) : IWordProcessor
{
    private readonly HashSet<string> boringWords = new(boringWords);

    public IEnumerable<string> ProcessWords(IEnumerable<string> words)
    {
        throw new NotImplementedException();
    }
}
