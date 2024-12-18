using System.Drawing;
using TagCloud.Settings;
using TagCloud.WordCounter;

namespace TagCloud.CloudPainter;

public class CloudPainter : ICloudPainter
{
	private ISettingsProvider _settingsProvider;

	public CloudPainter(ISettingsProvider settingsProvider)
	{
		_settingsProvider = settingsProvider;
	}

	public void Paint(List<Tag> tags)
	{
		var settings = _settingsProvider.GetSettings();

		using var bitmap = new Bitmap(settings.Width, settings.Height);
		using var graphics = Graphics.FromImage(bitmap);
		graphics.Clear(Color.White);
		var fontFamily = new FontFamily(settings.FontFamily);

		var random = new Random();
		foreach (var tag in tags)
		{
			var fontSize = 20;
			var font = new Font(fontFamily, fontSize);
			var color = Color.FromArgb(random.Next(100, 256), random.Next(100, 256), random.Next(100, 256));
			using var brush = new SolidBrush(color);
			graphics.DrawString(tag.Word, font, brush, tag.Location);
		}

		bitmap.Save(settings.SavePath, System.Drawing.Imaging.ImageFormat.Png);
	}
}