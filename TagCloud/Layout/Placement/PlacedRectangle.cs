using System.Drawing;

public class PlacedRectangle
{
    public RectangleF Bounds { get; }
    public TextRectangle TextRect { get; }

    public PlacedRectangle(RectangleF bounds, TextRectangle textRect)
    {
        Bounds = bounds;
        TextRect = textRect;
    }
}