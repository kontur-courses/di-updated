using System.Drawing;

namespace TagCloud.CloudDrawer;

public class CloudDrawer
{
    private DrawerSettings DrawerSettings;
    private int _width;
    private int _height;

    public CloudDrawer(DrawerSettings drawerSettings)
    {
        DrawerSettings = drawerSettings;
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
        // SaviorImages.SaveImage(bmp, fileName, "PNG");
    }
}