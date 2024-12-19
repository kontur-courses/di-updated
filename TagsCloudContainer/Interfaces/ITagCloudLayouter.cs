using System.Drawing;

namespace TagsCloudVisualization.Interfaces;

public interface ITagCloudLayouter
{
    Rectangle PutNextRectangle(Size rectangleSize);
    IEnumerable<Rectangle> GetRectangles();
}