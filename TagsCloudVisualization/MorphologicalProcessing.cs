using MyStemWrapper;
namespace TagsCloudVisualization;

public class MorphologicalProcessing
{
    public static bool IsExcludedWord(string word)
    {
        var mystem = new MyStem();
        mystem.PathToMyStem = "/Users/milana/di-updated/TagsCloudVisualization/mystem"; //перенести
        mystem.Parameters = "-ni";
        var res = mystem.Analysis(word);
        if (res.Contains("CONJ") || res.Contains("INTJ") 
        || res.Contains("PART") || res.Contains("PR") || res.Contains("SPRO"))
            return true;
        return false;
    }
}
