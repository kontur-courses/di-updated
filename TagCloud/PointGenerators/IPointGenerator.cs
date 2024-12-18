using System.Drawing;

namespace TagCloud.PointGenerators;

public interface IPointGenerator
{
    public Point GetPoint();
}