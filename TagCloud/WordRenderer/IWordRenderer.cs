using System.Drawing;
using TagCloud.WordStatistics;

namespace TagCloud.WordRenderer;

public interface IWordRenderer
{
    public Bitmap Render(IWordStatistics statistics);
}