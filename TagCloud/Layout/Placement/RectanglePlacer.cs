using System.Drawing;

public class RectanglePlacer(Size canvasSize) //IoC
{
    private readonly List<PlacedRectangle> _placedRectangles = new();

    public bool TryPlace(Size size, out Point position)
    {
        throw new NotImplementedException();
    }

    private bool CanPlaceAt(Point position, Size size)
    {
        var newRect = new Rectangle(position, size);


        if (newRect.Left < 0 || newRect.Top < 0 ||
            newRect.Right > canvasSize.Width ||
            newRect.Bottom > canvasSize.Height)
            return false;


        return !_placedRectangles.Any(p => p.Bounds.IntersectsWith(newRect));
    }

    public void AddPlacedRectangle(Point position, TextRectangle textRect)
    {
        var bounds = new RectangleF(
            position,
            new SizeF(textRect.Size.Width, textRect.Size.Height)
        );
        _placedRectangles.Add(new PlacedRectangle(bounds, textRect));
    }

    public List<PlacedRectangle> PlacedRectangles => _placedRectangles;
}