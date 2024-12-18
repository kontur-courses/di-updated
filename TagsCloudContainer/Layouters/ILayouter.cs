using System.Drawing;

namespace TagsCloudContainer.Layouters;

public interface ILayouter
{
    Rectangle PutNextRectangle(Size wordSize);
}