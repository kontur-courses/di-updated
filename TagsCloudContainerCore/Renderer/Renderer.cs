using Microsoft.Extensions.Logging;
using SkiaSharp;
using TagsCloudContainerCore.Models;

namespace TagsCloudContainerCore.Renderer;

public class Renderer : IRenderer
{
    private readonly SKFont _font;
    private readonly ILogger<IRenderer> _logger;
    private readonly SKPaint _paint;
    private SKBitmap _bitmap;

    public Renderer(ILogger<IRenderer> logger)
    {
        _logger = logger;
        _font = SKTypeface.Default.ToFont();
        _paint = new SKPaint
        {
            Color = SKColors.Black,
            IsStroke = true
        };
    }

    public void DrawTags(IEnumerable<Tag> tags, SKSize size)
    {
        _bitmap = new SKBitmap((int)size.Width, (int)size.Height);
        using var canvas = new SKCanvas(_bitmap);
        canvas.Clear(SKColors.LightGray);
        _logger.LogInformation("Drawing {0} tags", tags.Count());
        foreach (var tag in tags)
        {
            ValidateRectangle(tag.Rectangle);
            _paint.Color = tag.Color;
            _font.Size = tag.FontSize;

            var x = tag.Rectangle.Left;
            var y = tag.Rectangle.Bottom - _font.Metrics.Descent;

            canvas.DrawText(tag.Text, x, y, _font, _paint);
            canvas.DrawRect(tag.Rectangle, _paint);
        }

        _logger.LogInformation("Finished drawing tags");
    }

    public SKImage GetImage()
    {
        return SKImage.FromBitmap(_bitmap);
    }

    private void ValidateRectangle(SKRect rectangle)
    {
        if (rectangle.Left < 0 || rectangle.Top < 0 || rectangle.Right > _bitmap.Width ||
            rectangle.Bottom > _bitmap.Height)
            //throw new ArgumentException("Rectangle is out of bounds");
            _logger.LogWarning("Rectangle is out of bounds");
        if (rectangle.Left >= rectangle.Right || rectangle.Top >= rectangle.Bottom)
            //throw new ArgumentException("Rectangle is invalid");
            _logger.LogWarning("Rectangle is invalid");
    }
}