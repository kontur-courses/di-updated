using System.Drawing;
using System.Drawing.Imaging;
using TagsCloudVisualization.ConsoleCommands;
using TagsCloudVisualization.Domain;
using TagsCloudVisualization.Renderers.ColorGenerators;

namespace TagsCloudVisualization.Renderers;

public class DefaultRenderer : ICloudRenderer 
{
    private readonly IColorGenerator colorGenerator;
    private readonly string outputFilePath;
    private readonly Size imageSize;
    private readonly Color backgroundColor;

    public DefaultRenderer(IColorGenerator colorGenerator, Options options)
    {
        this.colorGenerator = colorGenerator;
        outputFilePath = options.OutputFilePath;
        imageSize = new Size(options.ImageWidth, options.ImageHeight);
        backgroundColor = Color.FromName(options.BackgroundColor);
    }
    
    public void Render(IEnumerable<Tag> tags)
    {
        if (!tags.Any())
            throw new ArgumentNullException(nameof(tags));
        
        using var bitmap = new Bitmap(imageSize.Width, imageSize.Height);
        using var graphic = Graphics.FromImage(bitmap);
        graphic.Clear(backgroundColor);
        foreach (var tag in tags)
        {
            var color = colorGenerator.GetColor();
            var brush = new SolidBrush(color);
            graphic.DrawString(tag.Content, tag.Font, brush, tag.Rectangle.Location);
        }
        
        SaveImage(bitmap, tags.Count());
    }

    private void SaveImage(Bitmap bitmap, int tagCount)
    {
        var filePath = Path.Combine(outputFilePath, $"cloud_{tagCount}.png");
        bitmap.Save(filePath, ImageFormat.Png);
    }
}