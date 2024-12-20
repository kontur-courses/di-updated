using System.Drawing;

namespace TagsCloudVisualization.CloudLayouter;

public interface ICloudLayouter
{
    public List<Rectangle> Rectangles { get; }
    public Rectangle PutNextRectangle(Size rectangleSize);
}