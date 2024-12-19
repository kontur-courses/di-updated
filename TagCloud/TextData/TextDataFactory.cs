using TagCloud.TextData;

public interface ITextDataFactory
{
    ITextData CreateTextData(string value);
    ITextData CreateWeightedTextData(string value, int weight);
}

public class TextDataFactory : ITextDataFactory
{
    public ITextData CreateTextData(string value)
    {
        return new SimpleText { Value = value };
    }

    public ITextData CreateWeightedTextData(string value, int weight)
    {
        return new TextDataWithWeight { Value = value, Weight = weight };
    }
} 