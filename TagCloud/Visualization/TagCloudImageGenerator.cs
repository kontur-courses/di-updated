using SkiaSharp;

namespace TagCloud.Visualization;

public class TagCloudImageGenerator
{
    public SKBitmap CreateBitmap(List<SKRect> rectangles)
    {
        var layoutSize = GetLayoutSize(rectangles);
        var bimapWidth = layoutSize.Width * 2;
        var bimapHeight = layoutSize.Height * 2;
        var bitmap = new SKBitmap(bimapWidth,  bimapHeight);
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
    
    private static SKSizeI GetLayoutSize(List<SKRect> rectangles)
    {
        var layoutWidth = rectangles.Max(r => r.Right) - rectangles.Min(r => r.Left);
        var layoutHeight = rectangles.Max(r => r.Top) - rectangles.Min(r => r.Bottom);
        
        return new SKSizeI((int)layoutWidth, (int)layoutHeight);
    }
}