using TagCloud.TextData;

public interface ITextSizeCalculator
{
    TextRectangle CalculateSize(ITextData textData, TextSizeConfiguration config);
}