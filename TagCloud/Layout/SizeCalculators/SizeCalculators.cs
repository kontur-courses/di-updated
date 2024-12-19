using System;
using System.Drawing;
using System.Net.Mime;
using TagCloud.TextData;

public class SimpleTextSizeCalculator : ITextSizeCalculator
{
    public TextRectangle CalculateSize(ITextData textData, TextSizeConfiguration config)
    {
        throw new NotImplementedException();
    }

    private float CalculateFontSize(float height, TextSizeConfiguration config)
    {
        throw new NotImplementedException();
    }
}

public class WeightBasedSizeCalculator : ITextSizeCalculator
{
    public TextRectangle CalculateSize(ITextData textData, TextSizeConfiguration config)
    {
        throw new NotImplementedException();
    }


    private float CalculateFontSize(float height, TextSizeConfiguration config)
    {
        throw new NotImplementedException();
    }
}