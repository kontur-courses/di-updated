using System.Drawing;
using FractalPainting.Application.Models;
using FractalPainting.Infrastructure.Common;
using Point = FractalPainting.Application.Models.Point;
using Rectangle = FractalPainting.Application.Models.Rectangle;

namespace FractalPainting.Application.Fractals;

public class DragonPainter(DragonSettings settings, IImageSettingsProvider imageSettingsProvider, Palette palette)
{
    public IReadOnlyCollection<Figure> Paint()
    {
        var imageSettings = imageSettingsProvider.ImageSettings;
        var size = Math.Min(imageSettings.Width, imageSettings.Height) / 2.1f;
        
        var figures = new List<Figure>();
        figures.Add(new Rectangle(imageSettings.Width, imageSettings.Height, new Point(0, 0), palette.BackgroundColor));
        var r = new Random();
        var cosa = (float)Math.Cos(settings.Angle1);
        var sina = (float)Math.Sin(settings.Angle1);
        var cosb = (float)Math.Cos(settings.Angle2);
        var sinb = (float)Math.Sin(settings.Angle2);
        var shiftX = settings.ShiftX * size * 0.8f;
        var shiftY = settings.ShiftY * size * 0.8f;
        var scale = settings.Scale;
        var p = new PointF(0, 0);
        foreach (var _ in Enumerable.Range(0, settings.IterationsCount))
        {
            figures.Add(new Rectangle(1, 1,
                new Point((int)(imageSettings.Width / 3f + p.X), (int)(imageSettings.Height / 2f + p.Y)),
                palette.PrimaryColor));
            if (r.Next(0, 2) == 0)
                p = new PointF(scale * (p.X * cosa - p.Y * sina), scale * (p.X * sina + p.Y * cosa));
            else
                p = new PointF(scale * (p.X * cosb - p.Y * sinb) + shiftX,
                    scale * (p.X * sinb + p.Y * cosb) + shiftY);
        }

        return figures;
    }
}