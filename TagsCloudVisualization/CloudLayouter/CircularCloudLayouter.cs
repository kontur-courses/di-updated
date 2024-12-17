﻿using System.Drawing;
using TagsCloudVisualization.Extension;
using TagsCloudVisualization.Generator;

namespace TagsCloudVisualization.CloudLayouter;

public class CircularCloudLayouter : ICloudLayouter
{
    public List<Rectangle> Rectangles { get; }
    private readonly Spiral spiral;
    private readonly Point center;

    public CircularCloudLayouter(Point center, IRectangleGenerator rectangleGenerator, int countRectangles)
    {
        this.center = center;
        spiral = new(center, 2);
        Rectangles = new(countRectangles);
        
        foreach (var rectangle in rectangleGenerator.GenerateRandomRectangles(countRectangles))
        {
            PutNextRectangle(rectangle.Size);
        }
    }
    
    public Rectangle PutNextRectangle(Size sizeRectangle)
    {
        var rectangle = FindNextValidRectanglePosition(sizeRectangle);
        rectangle = MoveRectangleCloserCenter(rectangle);
        Rectangles.Add(rectangle);

        return rectangle;
    }

    private Rectangle FindNextValidRectanglePosition(Size sizeRectangle)
    {
        if (sizeRectangle.Width <= 0 || sizeRectangle.Height <= 0)
            throw new ArgumentException("Width and height should be greater than zero.");

        Rectangle rectangle;

        while (true)
        {
            rectangle = new(spiral.GetNextPoint(), sizeRectangle);
            if (!rectangle.IntersectsWithAnyOf(Rectangles))
                break;
        }

        return rectangle;
    }

    private Rectangle MoveRectangleCloserCenter(Rectangle rectangle)
    {
        var xStepsToCenter = Math.Abs(rectangle.GetCenter().X - center.X);
        var xShiftDirection = rectangle.GetCenter().X < center.X ? 1 : -1;
        var xShiftVector = new Point(xShiftDirection, 0);

        var yStepsToCenter = Math.Abs(rectangle.GetCenter().Y - center.Y);
        var yShiftDirection = rectangle.GetCenter().Y < center.Y ? 1 : -1;
        var yShiftVector = new Point(0, yShiftDirection);

        var newRectangle = MoveRectangleAxis(rectangle,
            xStepsToCenter,
            xShiftVector);
        newRectangle = MoveRectangleAxis(newRectangle,
            yStepsToCenter,
            yShiftVector);

        return newRectangle;
    }

    private Rectangle MoveRectangleAxis(
        Rectangle newRectangle,
        int stepsToCenter,
        Point stepPoint)
    {
        var stepsTaken = 0;
        while (!newRectangle.IntersectsWithAnyOf(Rectangles) && stepsTaken != stepsToCenter)
        {
            newRectangle.Location = newRectangle.Location.Add(stepPoint);
            stepsTaken++;
        }

        if (newRectangle.IntersectsWithAnyOf(Rectangles))
        {
            newRectangle.Location = newRectangle.Location.Subtract(stepPoint);
        }

        return newRectangle;
    }
}