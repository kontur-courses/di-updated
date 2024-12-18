using System.Drawing;

namespace TagsCloudVisualization.LayoutAlgorithms;

public interface ILayoutAlgorithm
{
    Point CalculateNextPoint();
}