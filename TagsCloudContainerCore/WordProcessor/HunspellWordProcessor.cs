using WeCantSpell.Hunspell;

namespace TagsCloudContainerCore.WordProcessor;

public class HunspellWordProcessor : IWordProcessor
{
    private readonly WordList _wordList = WordList.CreateFromFiles("ru_RU.aff", "ru_RU.dic");

    public string ProcessWord(string word)
    {
        return _wordList.Suggest(word).FirstOrDefault() ?? word;
    }
}