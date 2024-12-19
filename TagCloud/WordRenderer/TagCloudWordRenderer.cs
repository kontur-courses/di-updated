using System.Drawing;
using System.Drawing.Drawing2D;
using TagCloud.Logger;
using TagCloud.SettingsProvider;
using TagCloud.TagsCloudVisualization;
using TagCloud.WordStatistics;

namespace TagCloud.WordRenderer;

public class TagCloudWordRenderer(
    ICircularCloudLayouter cloudLayouter,
    ISettingsProvider settingsProvider,
    ILogger logger
    ) : IWordRenderer
{
#pragma warning disable CA1416
    public Bitmap Render(IWordStatistics statistics)
    {
        var settings = settingsProvider.GetSettings();
        
        var imageSize = settings.ImageSize;
        var bitmap = new Bitmap(imageSize.Width, imageSize.Height);
        var graphics = Graphics.FromImage(bitmap);
        graphics.Clear(settings.BackgroundColor);
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        
        var words = statistics.GetWords().ToArray();
        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            var frequency = statistics.GetWordFrequency(word);
            var fontSize = settings.MinFontSize + (int)((settings.MaxFontSize - settings.MinFontSize) * frequency);
            var font = new Font(settings.Font, fontSize);
            var stringSize = graphics.MeasureString(word, font);
            var renderSize = new Size(1 + (int)stringSize.Width, (int)stringSize.Height);
            
            var rectangle = cloudLayouter.PutNextRectangle(renderSize);
            logger.ReportProgress($"Put {i + 1}/{words.Length} words", (double)i / (words.Length - 1));
            
            graphics.DrawString(word, font, new SolidBrush(settings.TextColor), rectangle);
            // graphics.DrawRectangle(new Pen(Color.Black, 2), rectangle);
        }
        
        graphics.Dispose();
        return bitmap;
    }
#pragma warning restore CA1416
}