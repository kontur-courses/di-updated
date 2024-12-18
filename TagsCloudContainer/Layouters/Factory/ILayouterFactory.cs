using System.Drawing;

namespace TagsCloudContainer.Layouters.Factory;

public interface ILayouterFactory
{
    public ILayouter CreateLayouter(Point center = new());
}