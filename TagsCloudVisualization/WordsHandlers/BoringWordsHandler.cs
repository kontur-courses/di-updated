namespace TagsCloudVisualization.WordsHandlers;

public class BoringWordsHandler(Mystem.Net.Mystem mystem) : IWordHandler
{
    public IEnumerable<string> Handle(IEnumerable<string> words)
    {
        foreach (var word in words)
        {
            var lemma = mystem.Mystem.Analyze(word).Result![0];

            var grammeme = lemma.AnalysisResults.First().Grammeme!;
            var speechPart = grammeme[..grammeme.IndexOf(',')];
            
            if (speechPart != "S" && speechPart != "V")
                continue;
            
            yield return word;
        }
    }
}