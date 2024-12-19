using TagCloud.TextData;

namespace TagCloud.TextProcesor;

public class TextProcessor(
    ITextDataFactory textDataFactory,
    IWeightStrategy weightStrategy,
    ITextFilter filter,
    bool useWeights = false)
    : ITextProcessor
{
    public IEnumerable<ITextData> GetProceedData(string input)
    {
        var words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        IEnumerable<ITextData> textData;
        if (!useWeights)
            textData = words.Select(w => textDataFactory.CreateTextData(w));
        else
            textData = words.Select(w => 
                textDataFactory.CreateWeightedTextData(w, weightStrategy.CalculateWeight(w)));

        return textData.Where(data => filter.ShouldKeep(data));
    }
}