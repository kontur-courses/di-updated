namespace TagsCloudContainer.TextAnalyzer.Logic.Analyzers.Interfaces;

internal interface IWordAnalyzer<TDetails>
{
    public bool TryAnalyzeWord(string word, out TDetails? details);

    public TDetails? AnalyzeWordOrNull(string word);
}