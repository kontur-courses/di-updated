using System.Drawing;
using TagCloud.CloudLayout;
using TagCloud.CloudDrawer;

namespace TagCloud;

public class RectanglesGenerator : IRectanglesGenerator
{
    
    public List<Rectangle> GenerateRectangles(int count, CircularCloud circularCloud)
    {
        var rnd = new Random();
        for (var i = 0; i < count; i++)
        {
            var width = rnd.Next(10, 25);
            var height = rnd.Next(10, 25);
            circularCloud.PutNextRectangle(new Size(width, height));
        }

        return circularCloud.GetRectangles();
    }

    public List<WordInShape> GetWordsInShape(IEnumerable<string> words)
    {
        throw new NotImplementedException();
    }
}