using System.Drawing;
using TagCloud;
using TagCloud.CloudDrawer;
using TagCloud.CloudLayout;

public static class Program
{
    public static void Main()
    {
        DrawerSettings drawerSettings = new DrawerSettings();
        CloudGenerator cloudGenerator = new CloudGenerator();
        drawerSettings.BackgroundColor = Color.White;
        CloudDrawer cloudDrawer = new CloudDrawer(drawerSettings);
        List<int> countOfRectangles = new List<int>() {50, 100, 400};
        foreach (var i in countOfRectangles)
        {
            CircularCloud circularCloud =
                new CircularCloud(drawerSettings.CloudCentre);
            var rectangles = cloudGenerator.GenerateRectangles(i, circularCloud);
            drawerSettings.BackgroundSize = circularCloud.GetCloudSize();
            var cloud = cloudDrawer.DrawRectangles(rectangles);

            SaviorImages.SaveImage(cloud, $"Rectangles{i}", "PNG");
        }
    }
}