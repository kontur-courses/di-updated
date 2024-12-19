using System.Drawing;

namespace TagsCloudContainer.Interfaces;

public interface IPointDistributor
{
    PointF GetNextPoint();
}