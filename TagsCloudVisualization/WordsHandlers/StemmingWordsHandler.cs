using WeCantSpell.Hunspell;

namespace TagsCloudVisualization.WordsHandlers;

public class StemmingWordsHandler(WordList dictionary) : IWordHandler
{
    public IEnumerable<string> Handle(IEnumerable<string> words) =>
        words.Select(word => dictionary.CheckDetails(word).Root);
}