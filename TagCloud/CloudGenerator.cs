using System.Drawing;
using TagCloud.CloudLayout;
using TagCloud.CloudDrawer;

namespace TagCloud;

public class CloudGenerator
{
    public List<Rectangle> GenerateRectangles(int count, CircularCloud circularCloud)
    {
        Random rnd = new Random();
        for (int i = 0; i < count; i++)
        {
            int width = rnd.Next(10, 25);
            int height = rnd.Next(10, 25);
            circularCloud.PutNextRectangle(new Size(width, height));
        }

        return circularCloud.GetRectangles();
    }
}