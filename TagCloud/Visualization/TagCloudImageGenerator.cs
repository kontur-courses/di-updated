using SkiaSharp;

namespace TagCloud.Visualization;

public class TagCloudImageGenerator(SKSizeI Size, SKTypeface fontFamily ,SKColor background, SKColor foreground)
{
    public SKBitmap CreateBitmap(List<SKRect> rectangles)
    {
        var bitmap = new SKBitmap(Size.Width,  Size.Height);
        var canvas = new SKCanvas(bitmap);
        var paint = new SKPaint 
        { 
            Color = SKColors.Black,
            Style = SKPaintStyle.Stroke
        };
        
        canvas.Clear(SKColors.White);
        
         var xOffset = bitmap.Width / 2f - rectangles.First().Location.X;
         var yOffset = bitmap.Height / 2f - rectangles.First().Location.Y;

        foreach (var rectangle in rectangles)
        {
            rectangle.Offset(xOffset, yOffset);
            canvas.DrawRect(rectangle, paint);
        }

        return bitmap;
    }
}