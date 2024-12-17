using System.Drawing;

namespace TagsCloudVisualization.Generator;

public interface IRectangleGenerator
{
    public IEnumerable<Rectangle> GenerateRandomRectangles(int countRectangles);
}