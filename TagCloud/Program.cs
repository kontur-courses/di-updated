using System.Drawing;
using TagCloud;
using TagCloud.CloudDrawer;
using TagCloud.CloudLayout;
using TagCloud.TextPreparator;

public static class Program
{
    public static void Main()
    {
        var drawerSettings = new DrawerSettings();
        var rectanglesGenerator = new RectanglesGenerator();
        var textFilter = new TextFilter();
        var textHandler = new TextHandler(textFilter);
        drawerSettings.BackgroundColor = Color.White;
        var cloudDrawer = new CloudDrawer(drawerSettings, textHandler, rectanglesGenerator);
        var countOfRectangles = new List<int>() {50, 100, 400};
        foreach (var i in countOfRectangles)
        {
            var circularCloud = new CircularCloud(drawerSettings.CloudCentre);
            var rectangles = rectanglesGenerator.GenerateRectangles(i, circularCloud);
            drawerSettings.BackgroundSize = circularCloud.GetCloudSize();
            var cloud = cloudDrawer.DrawRectangles(rectangles);

            SaviorImages.SaveImage(cloud, $"Rectangles{i}", "PNG");
        }
    }
}