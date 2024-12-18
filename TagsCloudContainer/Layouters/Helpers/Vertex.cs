﻿using System.Drawing;

namespace TagsCloudContainer.Layouters.Helpers;

public record struct Vertex(Point Location, int Length, Direction Direction)
{
    public static IEnumerable<Vertex> GetRectangleVertices(Rectangle rectangle, Direction direction)
    {
        for (var i = 0; i < 4; i++)
        {
            direction = direction.NextDirection();
            yield return GetRectangleVertex(rectangle, direction);
        }
    }
    
    public static Vertex GetRectangleVertex(Rectangle rectangle, Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return new Vertex(rectangle.Location, rectangle.Size.Width, Direction.Up);
            case Direction.Right:
            {
                var location = rectangle.Location with { X = rectangle.Location.X + rectangle.Size.Width };
                return new Vertex(location, rectangle.Size.Height, Direction.Right);
            }
            case Direction.Down:
            {
                var location = new Point(rectangle.Location.X + rectangle.Size.Width,
                    rectangle.Location.Y + rectangle.Size.Height);
                return new Vertex(location, rectangle.Size.Width, Direction.Down);
            }
            case Direction.Left:
            {
                var location = rectangle.Location with { Y = rectangle.Location.Y + rectangle.Size.Height };
                return new Vertex(location, rectangle.Size.Height, Direction.Left);
            }
            default:
                throw new ArgumentOutOfRangeException($"Неожиданное значение Direction: {direction}");
        }
    }
}