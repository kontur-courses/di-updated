using System.Drawing;

namespace TagsCloudVisualization.CircularCloudLayouters;

public interface ICircularCloudLayouter
{
    Rectangle PutNextRectangle(Size rectangleSize);
}