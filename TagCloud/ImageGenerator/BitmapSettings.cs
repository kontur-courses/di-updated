using System.Drawing;

namespace TagCloud.ImageGenerator;

public record BitmapSettings(
    Size Sizes,
    FontFamily Font,
    string ImageName,
    Color BackgroundColor, 
    Color ForegroundColor);