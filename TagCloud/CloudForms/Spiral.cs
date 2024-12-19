using System.Drawing;

namespace TagCloud.CloudForms;

public class Spiral : ICloudForm
{
    private readonly Point center;
    private readonly double angleStep;
    private double angle;


    public Spiral(Point center, double angleStep = 0.01)
    {
        this.center = center;
        this.angleStep = angleStep;
        angle = 0;
    }

    public Point GetNextPoint()
    {
        angle += angleStep;
        var x = (int) (center.X + angle * Math.Cos(angle));
        var y = (int) (center.Y + angle * Math.Sin(angle));
        return new Point(x, y);
    }
}