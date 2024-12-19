using System.Drawing;

namespace TagCloud.CloudDrawer;

public class DrawerSettings
{
    public Color BackgroundColor { get; set; }
    public Size BackgroundSize { get; set; }
    public Point CloudCentre { get; } = new Point(500, 500);
}