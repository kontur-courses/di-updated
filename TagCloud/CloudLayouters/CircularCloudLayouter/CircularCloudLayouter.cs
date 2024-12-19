﻿using System.Drawing;

namespace TagCloud.CloudLayouters.CircularCloudLayouter
{
    // Класс, со старого задания TagCloud,
    // который расставляет прямоугольники по окружности
    // с постепенно увеличивающимся радиусом
    internal class CircularCloudLayouter(Point center) : ICloudLayouter
    {
        private readonly Circle arrangementСircle = new Circle(center);
        private readonly Random random = new Random();
        private readonly List<Rectangle> rectangles = new List<Rectangle>();

        public Rectangle PutNextRectangle(Size rectangleSize)
        {
            if (rectangleSize.Width <= 0 || rectangleSize.Height <= 0)
            {
                throw new ArgumentException(
                    "Размеры прямоугольника не могут быть меньше либо равны нуля.");
            }

            var result = new Rectangle();
            arrangementСircle.Radius -= 1.0f;

            var isPlaced = false;
            while (!isPlaced)
            {
                var startAngle = random.Next(360);
                foreach (var coordinate in arrangementСircle.GetCoordinatesOnCircle(startAngle))
                {
                    var location = GetRectangleLocation(coordinate, rectangleSize);
                    var nextRectangle = new Rectangle(location, rectangleSize);
                    if (!IsIntersectionWithAlreadyPlaced(nextRectangle))
                    {
                        rectangles.Add(nextRectangle);
                        isPlaced = true;
                        result = nextRectangle;
                        break;
                    }
                }

                arrangementСircle.Radius += 1.0f;
            }

            return result;
        }

        private bool IsIntersectionWithAlreadyPlaced(Rectangle rectangle)
        {
            foreach (var rect in rectangles)
            {
                if (rect.IntersectsWith(rectangle))
                {
                    return true;
                }
            }

            return false;
        }

        private Point GetRectangleLocation(Point pointOnCircle, Size rectangleSize)
        {
            var x = pointOnCircle.X - rectangleSize.Width / 2;
            var y = pointOnCircle.Y - rectangleSize.Height / 2;
            return new Point(x, y);
        }
    }
}
