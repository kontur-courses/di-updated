using System.Drawing;

namespace TagCloud.CloudLayouterPainters
{
    // Интерфейс отрисовки прямоугольников
    internal interface ICloudLayouterPainter
    {
        public Bitmap Draw(IList<Rectangle> rectangles);
    }
}
