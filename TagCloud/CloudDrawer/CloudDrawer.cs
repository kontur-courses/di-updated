using System.Drawing;
using Microsoft.Maui.Graphics;
using TagCloud.TextPreparator;
using Color = System.Drawing.Color;

namespace TagCloud.CloudDrawer;

public class CloudDrawer : ICloudDrawer
{
    public DrawerSettings DrawerSettings { get; set; }
    public ITextHandler TextHandler { get; set; }
    public IRectanglesGenerator RectanglesGenerator { get; set; }
    private int _width;
    private int _height;

    public CloudDrawer(DrawerSettings drawerSettings, TextHandler textHandler, RectanglesGenerator rectanglesGenerator)
    {
        DrawerSettings = drawerSettings;
        TextHandler = textHandler;
        RectanglesGenerator = rectanglesGenerator;
    }


    public Bitmap DrawRectangles(List<Rectangle> rectangles)
    {
        _width = DrawerSettings.BackgroundSize.Width;
        _height = DrawerSettings.BackgroundSize.Height;
        var bmp = new Bitmap(_width, _height);
        using var newGraphics = Graphics.FromImage(bmp);
        using var backgroundBrush = new SolidBrush(DrawerSettings.BackgroundColor);
        using var rectanglePen = new Pen(Color.Black);
        newGraphics.FillRectangle(backgroundBrush, 0, 0, _width, _height);
        foreach (var rectangle in rectangles)
        {
            newGraphics.DrawRectangle(rectanglePen, rectangle);
        }

        return bmp;
    }


    public ICanvas DrawCloud(ICanvas canvas)
    {
        throw new NotImplementedException();
    }
}