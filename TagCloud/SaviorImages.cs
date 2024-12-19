using System.Drawing;

namespace TagCloud;

public class SaviorImages
{
    public static void SaveImage(Bitmap bmp, string fileName, string imageFormat)
    {
        fileName = $"{fileName}.{imageFormat.ToLower()}";
        bmp.Save(fileName);
    }
}