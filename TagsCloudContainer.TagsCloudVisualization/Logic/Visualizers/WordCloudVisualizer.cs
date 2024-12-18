using System.Drawing;
using TagsCloudContainer.TagsCloudVisualization.Logic.Layouters.Interfaces;
using TagsCloudContainer.TagsCloudVisualization.Logic.SizeCalculators.Interfaces;
using TagsCloudContainer.TagsCloudVisualization.Logic.Visualizers.Interfaces;
using TagsCloudContainer.TagsCloudVisualization.Models;
using TagsCloudContainer.TagsCloudVisualization.Models.Settings;

namespace TagsCloudContainer.TagsCloudVisualization.Logic.Visualizers;

public class WordsCloudVisualizer(ICircularCloudLayouter container, IWeigherWordSizer weigherWordSizer)
    : IWordsCloudVisualizer
{
    public void SaveImage(Image image, ImageSettings settings, string outputFilePath)
    {
        image.Save(outputFilePath, settings.ImageFormat);
    }

    public Image CreateImage(ImageSettings settings, IReadOnlyDictionary<string, int> wordCounts)
    {
        var viewWords = weigherWordSizer.CalculateWordSizes(wordCounts);
        var bitmap = CreateImageMap(settings);
        var image = VisualizeWords(bitmap, viewWords, settings);
        return image;
    }

    private Bitmap CreateImageMap(ImageSettings imageSettings)
    {
        var bitmap = new Bitmap(imageSettings.Size.Width, imageSettings.Size.Height);
        using var g = Graphics.FromImage(bitmap);
        g.Clear(imageSettings.BackgroundColor);
        return bitmap;
    }

    private Image VisualizeWords(Image bitmap, IReadOnlyCollection<ViewWord> viewWords, ImageSettings imageSettings)
    {
        using var graphics = Graphics.FromImage(bitmap);
        foreach (var viewWord in viewWords)
        {
            var textSize = CalculateWordSize(graphics, viewWord);
            var rectangle = container.PutNextRectangle(textSize);
            DrawTextInRectangle(graphics, viewWord, rectangle, imageSettings);
        }

        return bitmap;
    }

    private Size CalculateWordSize(Graphics graphics, ViewWord viewWord)
    {
        var textSize = graphics.MeasureString(viewWord.Word, viewWord.Font);
        var viewWidth = (int) Math.Ceiling(textSize.Width);
        var viewHeight = (int) Math.Ceiling(textSize.Height);
        var viewSize = new Size(viewWidth, viewHeight);
        return viewSize;
    }

    private void DrawTextInRectangle(Graphics graphics, ViewWord viewWord, Rectangle rectangle,
        ImageSettings imageSettings)
    {
        using var sf = new StringFormat {Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center};
        using var brush = new SolidBrush(imageSettings.WordColor);
        graphics.DrawString(viewWord.Word, viewWord.Font, brush, rectangle, sf);
    }
}