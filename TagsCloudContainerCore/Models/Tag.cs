using SkiaSharp;

namespace TagsCloudContainerCore.Models;

public class Tag
{
    public SKColor Color;
    public int FontSize;
    public SKRect Rectangle;
    public required string Text;
}