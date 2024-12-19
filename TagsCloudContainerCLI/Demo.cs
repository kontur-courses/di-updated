using Autofac;
using SkiaSharp;
using TagsCloudContainerCore.ImageEncoders;
using TagsCloudContainerCore.Layouter;
using TagsCloudContainerCore.Models;
using TagsCloudContainerCore.Renderer;

namespace TagsCloudContainerCLI;

public class Demo
{
    private readonly IImageEncoder _encoder;
    private readonly ICircularCloudLayouter _layouter;
    private readonly IRenderer _renderer;
    private readonly ILifetimeScope _scope;

    public Demo(ILifetimeScope scope)
    {
        _scope = scope;
        _layouter = _scope.Resolve<ICircularCloudLayouter>();
        _renderer = _scope.Resolve<IRenderer>();
        _encoder = _scope.Resolve<IImageEncoder>();
    }

    public void GenerateDemo()
    {
        Directory.CreateDirectory("results");

        RenderCloud(GenerateRandomCloud(10), "results/cloud_10.png");
        RenderCloud(GenerateRandomCloud(50), "results/cloud_50.png");
        RenderCloud(GenerateRandomCloud(100), "results/cloud_100.png");
    }

    private Tag[] GenerateRandomCloud(int count)
    {
        var tags = new Tag[count];

        _layouter.SetCenter(new SKPoint(500, 500));

        for (var i = 0; i < count; i++)
        {
            var fontSize = new Random().Next(10, 50);
            var font = SKTypeface.Default.ToFont();
            font.Size = fontSize;
            var text = $"Tag{i}";
            var textWidth = font.MeasureText(text);

            var tag = new Tag
            {
                Text = text,
                FontSize = fontSize,
                Color = new SKColor((byte)new Random().Next(0, 255), (byte)new Random().Next(0, 255),
                    (byte)new Random().Next(0, 255)),
                Rectangle = _layouter.PutNextRectangle(new SKSize(textWidth, fontSize))
            };
            tags[i] = tag;
        }

        return tags;
    }

    private void RenderCloud(Tag[] tags, string path)
    {
        _renderer.DrawTags(tags, new SKSize(1000, 1000));
        var image = _encoder.Encode(_renderer.GetImage());
        using var stream = File.OpenWrite(path);
        image.SaveTo(stream);
    }
}