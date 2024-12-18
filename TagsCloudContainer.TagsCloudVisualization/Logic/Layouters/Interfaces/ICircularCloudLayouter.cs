using System.Drawing;

namespace TagsCloudContainer.TagsCloudVisualization.Logic.Layouters.Interfaces;

public interface ICircularCloudLayouter
{
    public Rectangle PutNextRectangle(Size rectangleSize);
}