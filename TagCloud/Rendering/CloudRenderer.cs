using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

public class CloudRenderer
{
    private readonly Size _canvasSize;

    public CloudRenderer(Size canvasSize, string fontFamily = "Arial")
    {
        _canvasSize = canvasSize;
    }

    public void RenderToFile(IEnumerable<PlacedRectangle> placedRectangles, string filePath) //TODO: вынести сохранения в отдельный конфигурируемый класс/метод
    {
        using var bitmap = new Bitmap(_canvasSize.Width, _canvasSize.Height);
        using var graphics = Graphics.FromImage(bitmap);
        graphics.Clear(Color.White);

        foreach (var placed in placedRectangles)
        {
            DrawText(graphics, placed);
        }

        bitmap.Save(filePath, ImageFormat.Png);
    }

    private void DrawText(Graphics graphics, PlacedRectangle placed)
    {
        using var font = placed.TextRect.Font;

        var format = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        graphics.DrawString(
            placed.TextRect.TextData.Value,
            font,
            Brushes.Black,
            placed.Bounds,
            format
        );
    }
}