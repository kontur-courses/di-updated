using System.Drawing;
using TagCloud.TextData;

public interface ITextSizeCalculatorFactory
{
    ITextSizeCalculator CreateCalculator(ITextData textData);
}

public class TextSizeCalculatorFactory : ITextSizeCalculatorFactory
{
    private readonly SimpleTextSizeCalculator _simpleCalculator;
    private readonly WeightBasedSizeCalculator _weightedCalculator;

    public TextSizeCalculatorFactory()
    {
        _simpleCalculator = new SimpleTextSizeCalculator();
        _weightedCalculator = new WeightBasedSizeCalculator();
    }


    public ITextSizeCalculator CreateCalculator(ITextData textData)
    {
        return textData is ITextWeight ? _weightedCalculator : _simpleCalculator;
    }

    public static SizeF MeasureString(string text, Font font)
    {
        using var bitmap = new Bitmap(1, 1);
        using var graphics = Graphics.FromImage(bitmap);
        return graphics.MeasureString(text, font);
    }
}