using System.Drawing;

namespace TagsCloudVisualization;

public class RectangleInformation
{
    public readonly Rectangle rectangle;
    public readonly string word;

    public RectangleInformation(Rectangle rectangle, string word)
    {
        this.word = word;
        this.rectangle = rectangle;
    }
}