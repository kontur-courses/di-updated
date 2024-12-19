using System.Drawing;

namespace TagsCloudVisualization.Interfaces;

public interface IPointGenerator
{
    Point GetNextPoint();
}