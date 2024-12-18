using System.Drawing;

namespace TagsCloudVisualization;

public class RectangleGenerator
{
    private static List<RectangleInformation> rectangleInformation = [];
    private static Dictionary<string, Size> rectangleData = [];
    private static void GenerateRectangles(Dictionary<string, int> frequencyRectangles)
    {
        var totalCountWords = frequencyRectangles.Sum(x => x.Value);
        var sortedWords = frequencyRectangles.OrderByDescending(word => word.Value);
        foreach (var word in sortedWords)
        {
            var width = word.Value * 300 / totalCountWords;
            var height = word.Value * 170 / totalCountWords;
            var rectangleSize = new Size(Math.Max(width, 1), Math.Max(height, 1));
            rectangleData.Add(word.Key, rectangleSize);
        }
    }
    private static List<RectangleInformation> PutRectangles(Point center)
    {
        var layouter = new CircularCloudLayouter(center);
        foreach (var rect in rectangleData)
        {
            var tempRect = layouter.PutNextRectangle(rect.Value);
            rectangleInformation.Add(new RectangleInformation(tempRect, rect.Key));
        }
        return rectangleInformation;
    }
    public static List<RectangleInformation> ExecuteRectangles(Dictionary<string, int> frequencyRectangles, Point center)
    {
        GenerateRectangles(frequencyRectangles);
        return PutRectangles(center);
    }

}