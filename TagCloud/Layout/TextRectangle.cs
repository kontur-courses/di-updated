using System.Drawing;
using TagCloud.TextData;


public class TextRectangle
{
    public SizeF Size { get; set; }
    public ITextData TextData { get; set; }
    public Font Font { get; set; }

    public TextRectangle(ITextData textData, SizeF size, Font font)
    {
        TextData = textData;
        Size = size;
        Font = font;
    }
} 