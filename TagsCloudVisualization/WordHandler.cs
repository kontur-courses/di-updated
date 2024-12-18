using System.Drawing;

namespace TagsCloudVisualization;

public class WordHandler
{
    private static readonly Dictionary<string, int> keyValueWords = [];

    public static Dictionary<string, int> ProcessFile(IFileProcessor fileProcessor, string filePath)
    {
        var words = fileProcessor.ReadWords(filePath);

        foreach (var word in words)
        {
            var normalizedWord = word.ToLower();

            if (!MorphologicalProcessing.IsExcludedWord(word))
            {   
                if (keyValueWords.ContainsKey(normalizedWord))
                    keyValueWords[normalizedWord]++;
                else
                    keyValueWords[normalizedWord] = 1;
            }
        }
        return keyValueWords;
    }
}