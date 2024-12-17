using System.Drawing;

namespace TagsCloudVisualization.Generator;

public class RectangleGenerator : IRectangleGenerator
{
    public IEnumerable<Rectangle> GenerateRandomRectangles(int countRectangles)
    {
        var random = new Random();
        
        for (var i = 0; i < countRectangles; i++)
        {
            var size = new Size(random.Next(20,100), random.Next(10, 40));
            yield return new Rectangle(new Point(), size);
        }
    }
}