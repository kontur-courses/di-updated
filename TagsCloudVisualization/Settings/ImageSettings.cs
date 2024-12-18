using System.Drawing;

namespace TagsCloudVisualization.Settings;

public class ImageSettings
{
    public ImageSettings(int width, int height, Color backgroundColor)
    {
        Width = width;
        Height = height;
        BackgroundColor = backgroundColor;
    }

    public int Width { get; }
    
    public int Height { get; }
    
    public Color BackgroundColor { get; }
}