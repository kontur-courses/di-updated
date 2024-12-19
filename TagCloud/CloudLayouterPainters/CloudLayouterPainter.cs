using System.Drawing;

namespace TagCloud.CloudLayouterPainters
{
    // Класс, со старого задания TagCloud,
    // Который отрисовывает прямоугольники.
    // В текущей реализации размер изображения определяется автоматически,
    // А первый поставленный прямоугольник всегда находится в центре изображения
    internal class CloudLayouterPainter(
        Color? backgroundColor = null,
        Color? rectangleBorderColor = null,
        int? paddingPerSide = null) : ICloudLayouterPainter
    {
        private readonly int paddingPerSide = paddingPerSide ?? 10;
        private readonly Color backgroundColor = backgroundColor ?? Color.White;
        private readonly Color rectangleBorderColor = rectangleBorderColor ?? Color.Black;

        public Bitmap Draw(IList<Rectangle> rectangles)
        {
            if (rectangles.Count == 0)
            {
                throw new ArgumentException("Список прямоугольников пуст.");
            }

            var minimums = new Point(rectangles.Min(r => r.Left), rectangles.Min(r => r.Top));
            var maximums = new Point(rectangles.Max(r => r.Right), rectangles.Max(r => r.Bottom));

            var imageSize = GetImageSize(minimums, maximums, paddingPerSide);
            var result = new Bitmap(imageSize.Width, imageSize.Height);

            using var graphics = Graphics.FromImage(result);
            graphics.Clear(backgroundColor);
            using var pen = new Pen(rectangleBorderColor, 1);
            for (var i = 0; i < rectangles.Count; i++)
            {
                var positionOnCanvas = GetPositionOnCanvas(
                    rectangles[i],
                    minimums,
                    paddingPerSide);
                graphics.DrawRectangle(
                    pen,
                    positionOnCanvas.X,
                    positionOnCanvas.Y,
                    rectangles[i].Width,
                    rectangles[i].Height);
            }

            return result;
        }

        private Point GetPositionOnCanvas(Rectangle rectangle, Point minimums, int padding)
            => new Point(rectangle.X - minimums.X + padding, rectangle.Y - minimums.Y + padding);

        private Size GetImageSize(Point minimums, Point maximums, int paddingPerSide)
            => new Size(maximums.X - minimums.X + 2 * paddingPerSide, maximums.Y - minimums.Y + 2 * paddingPerSide);
    }
}
