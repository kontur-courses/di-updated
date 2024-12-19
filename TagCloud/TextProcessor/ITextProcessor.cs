using TagCloud.TextData;

namespace TagCloud.TextProcesor;

public interface ITextProcessor
{
    IEnumerable<ITextData> GetProceedData(string input);
}