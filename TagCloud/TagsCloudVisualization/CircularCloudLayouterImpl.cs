using System.Drawing;

namespace TagCloud.TagsCloudVisualization;

public class CircularCloudLayouterImpl : ICircularCloudLayouter
{
    private static readonly float TracingStep = 0.001f;
    private static readonly float MaxTracingDistance = 1000f;
    private static readonly int MaxCycleCount = 7;

    public Point CloudCenter
    {
        get => _cloudCenter;
        set
        {
            if (_generatedLayout.Count > 0)
            {
                throw new InvalidOperationException("Can not change cloud center after generation start");
            }
            _cloudCenter = value;
        }
    }
    
    public IEnumerable<Rectangle> Layout => _generatedLayout.AsEnumerable();

    private Point _cloudCenter;
    private List<Rectangle> _generatedLayout = new();
    private double _nextAngle;
    private double _angleStep = Math.PI / 32;
    private int _currentCycle;
    private float _startingStep = 0.0f;
    
    public CircularCloudLayouterImpl(Point center)
    {
        CloudCenter = center;
    }

    public Rectangle PutNextRectangle(Size rectangleSize)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(rectangleSize.Width, "Width");
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(rectangleSize.Height, "Height");
        
        if (_generatedLayout.Count == 0)
        {
            var rectangle = new Rectangle(
                CloudCenter.X - rectangleSize.Width / 2,
                CloudCenter.Y - rectangleSize.Height / 2,
                rectangleSize.Width,
                rectangleSize.Height);
            _generatedLayout.Add(rectangle);
            return rectangle;
        }

        var nextRectangle = GetNextRectangle(rectangleSize);
        _generatedLayout.Add(nextRectangle);
        return nextRectangle;
    }

    private Rectangle GetNextRectangle(Size rectangleSize)
    {
        var found = false;
        var direction = GetNextDirection();
        var resultList = new List<Rectangle>();
        var stepSum = 0.0f;
        var iterationCount = 0;
        while (_nextAngle != 0)
        {
            var step = _startingStep;
            var result = Rectangle.Empty;
            while (step < 1f && !found)
            {
                (step, var availablePos) = FindNextAvailablePosByTracingLine(direction, step);
                found = TryFindGoodRectanglePosition(availablePos, rectangleSize, out result);
            }
            
            if (found)
                resultList.Add(result);
            found = false;
            direction = GetNextDirection();
            stepSum += step;
            iterationCount++;
        }
        
        var averageStep = stepSum / iterationCount;
        if (averageStep >= _startingStep + 0.05f)
            _startingStep = (float)Math.Round(averageStep, 2, MidpointRounding.ToZero);

        return resultList.MinBy(rect => rect.RectangleCenter().SquaredDistanceTo(_cloudCenter));
    }

    private bool TryFindGoodRectanglePosition(Point posToPlace, Size rectangleSize, out Rectangle result)
    {
        var possibleOptions = new Rectangle[]
        {
            new Rectangle(
                posToPlace.X,
                posToPlace.Y,
                rectangleSize.Width,
                rectangleSize.Height),
            new Rectangle(
                posToPlace.X - rectangleSize.Width,
                posToPlace.Y,
                rectangleSize.Width,
                rectangleSize.Height),
            new Rectangle(
                posToPlace.X,
                posToPlace.Y - rectangleSize.Height,
                rectangleSize.Width,
                rectangleSize.Height),
            new Rectangle(
                posToPlace.X - rectangleSize.Width,
                posToPlace.Y - rectangleSize.Height,
                rectangleSize.Width,
                rectangleSize.Height)
        };
        
        foreach (var option in possibleOptions)
        {
            bool intersects = false;
            foreach (var rectangle in _generatedLayout)
            {
                if (rectangle.IntersectsWith(option))
                {
                    intersects = true;
                    break;
                }
            }

            if (!intersects)
            {
                result = option;
                return true;
            }
        }
        
        result = Rectangle.Empty;
        return false;
    }

    private (float, Point) FindNextAvailablePosByTracingLine(PointF direction, float startingStep = 0.0f)
    {
        var nextPos = new PointF(
            CloudCenter.X + direction.X * MaxTracingDistance * TracingStep,
            CloudCenter.Y + direction.Y * MaxTracingDistance * TracingStep);
        var currentStep = startingStep == 0.0f ? TracingStep : startingStep;
        var notInRectangle = false;
        while (!notInRectangle)
        {
            notInRectangle = true;
            foreach (var rectangle in _generatedLayout)
            {
                if (rectangle.ContainsFloat(nextPos))
                {
                    notInRectangle = false;
                    break;
                }
            }
            currentStep += TracingStep;
            nextPos = new PointF(
                CloudCenter.X + direction.X * MaxTracingDistance * currentStep,
                CloudCenter.Y + direction.Y * MaxTracingDistance * currentStep);
        }

        return (currentStep, Point.Truncate(nextPos));
    }

    private PointF GetNextDirection()
    {
        var x = (float)Math.Cos(_nextAngle);
        var y = (float)Math.Sin(_nextAngle);
        _nextAngle += _angleStep;
        if (Math.Abs(_nextAngle - Math.PI * 2) < 1e-12f)
            _nextAngle = 0;
        return new PointF(x, y);
    }
}