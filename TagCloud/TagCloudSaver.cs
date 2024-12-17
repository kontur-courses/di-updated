using SkiaSharp;

namespace TagCloud;

public static class TagCloudSaver
{
    private const int ImageQuality = 80;
    
    public static string SaveAsPng(SKBitmap bitmap, string filePath)
    {
        var defaultImagePath = $"../../../imgs/{DateTime.Now:yy-MM-dd-HH-mm}";
        var path = Path.GetDirectoryName(filePath) ?? defaultImagePath; 
        Directory.CreateDirectory(path);
        using var file = File.OpenWrite($"{filePath}.png");
        bitmap.Encode(SKEncodedImageFormat.Png, ImageQuality).SaveTo(file);
        return path;
    }
}