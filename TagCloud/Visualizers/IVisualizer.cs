using System.Drawing;

namespace TagCloud.Visualizers;

public interface IVisualizer
{
    public Bitmap CreateBitmap(IEnumerable<Rectangle> rectangles, Size bitmapSize);
}