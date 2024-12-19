namespace TagCloud.TextData;

public class TextDataWithWeight : ITextData, ITextWeight
{
    public string Value { get; set; }
    public int Weight { get; set; }
}