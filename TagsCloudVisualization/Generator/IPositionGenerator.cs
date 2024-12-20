using System.Drawing;

namespace TagsCloudVisualization.Generator;

public interface IPositionGenerator
{
    public Point Center { get; }
    public Point GetNextPoint();
}