using System.Drawing;

namespace TagsCloudContainer.Interfaces;

public interface ICloudLayouter
{
    RectangleF PutNextRectangle(SizeF rectangleSize);
}