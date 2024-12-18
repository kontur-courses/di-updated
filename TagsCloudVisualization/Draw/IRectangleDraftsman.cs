using System.Drawing;

namespace TagsCloudVisualization.Draw;

public interface IRectangleDraftsman
{
    public Bitmap Bitmap { get; }
    public void CreateImage(IEnumerable<Rectangle> objects);
}