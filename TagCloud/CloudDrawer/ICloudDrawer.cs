using Microsoft.Maui.Graphics;
using TagCloud.TextPreparator;

namespace TagCloud.CloudDrawer;


public interface ICloudDrawer
{
    public DrawerSettings DrawerSettings { get; set; }
    public ITextHandler TextHandler { get; set; }
    public IRectanglesGenerator RectanglesGenerator {get; set;}
    
    public ICanvas DrawCloud(ICanvas canvas);
}