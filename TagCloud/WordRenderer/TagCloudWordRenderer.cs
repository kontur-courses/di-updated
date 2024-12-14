using System.Drawing;
using System.Drawing.Drawing2D;
using TagCloud.TagsCloudVisualization;
using TagCloud.WordStatistics;

namespace TagCloud.WordRenderer;

public class TagCloudWordRenderer(
    ICircularCloudLayouter cloudLayouter,
    IWordRenderSizeProvider wordRenderSizeProvider,
    IImageSizeProvider imageSizeProvider
    ) : IWordRenderer
{
#pragma warning disable CA1416
    public Bitmap Render(IWordStatistics statistics)
    {
        var imageSize = imageSizeProvider.ImageSize;
        var bitmap = new Bitmap(imageSize.Width, imageSize.Height);
        var graphics = Graphics.FromImage(bitmap);
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        
        foreach (var word in statistics.GetWords())
        {
            var rectangle = cloudLayouter.PutNextRectangle(
                wordRenderSizeProvider.GetWordRenderSize(
                    statistics.GetWordFrequency(word)));
            
            graphics.DrawString(word, new Font(FontFamily.GenericMonospace, 8), Brushes.Black, rectangle);
        }
        
        graphics.Dispose();
        return bitmap;
    }
#pragma warning restore CA1416
}