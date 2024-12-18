using System.Drawing;

namespace TagsCloudVisualization.Generator;

public interface IBitmapGenerator
{
    public Bitmap GenerateBitmap(IEnumerable<TagWord> words);
}