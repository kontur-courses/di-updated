using SkiaSharp;

namespace TagCloud.Visualization;

public static class TagCloudSaver
{
    private const int ImageQuality = 80;
    private const string DefaultImageDirectory = "../../../imgs";
    
    public static string Save(SKBitmap bitmap, string filePath, 
        SKEncodedImageFormat format = SKEncodedImageFormat.Png)
    {
        var defaultImagePath = Path.Combine(DefaultImageDirectory, $"{DateTime.Now:yy-MM-dd-HH-mm}");
        var path = Path.GetDirectoryName(filePath) ?? defaultImagePath; 
        Directory.CreateDirectory(path);
        var formatName = Enum.GetName(typeof(SKEncodedImageFormat), format)!.ToLower(); 
        using var file = File.OpenWrite($"{filePath}.{formatName}");
        bitmap.Encode(format, ImageQuality).SaveTo(file);
        
        return path;
    }
}