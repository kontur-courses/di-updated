using SkiaSharp;
using TagsCloudContainerCore.Models;

namespace TagsCloudContainerCore.Renderer;

public interface IRenderer
{
    void DrawTags(IEnumerable<Tag> tags, SKSize size);

    SKImage GetImage();
}