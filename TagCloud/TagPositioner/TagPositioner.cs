using System.Drawing;
using TagCloud.Settings;
using TagCloud.TagPositioner.Circular;
using TagCloud.WordCounter;

namespace TagCloud.TagPositioner;

public class TagPositioner : ITagPositioner
{
	private readonly ICloudLayouter _cloudLayouter;
	private readonly ISettingsProvider _settingsProvider;

	public TagPositioner(ICloudLayouter cloudLayouter, ISettingsProvider settingsProvider)
	{
		_cloudLayouter = cloudLayouter;
		_settingsProvider = settingsProvider;
	}
	public List<Tag> Position(List<Tag> tags)
	{
		var settings = _settingsProvider.GetSettings();
		var size = new Size(settings.Width, settings.Height);
		var center = new Point(size.Width / 2, size.Height / 2);
		var bitmap = new Bitmap(size.Width, size.Height);
		var graphics = Graphics.FromImage(bitmap);

		var fontFamily = new FontFamily(settings.FontFamily);
		var rectangels = new List<Rectangle>();

		foreach (var tag in tags)
		{
			var fontSize = 20;
			var font = new Font(fontFamily, fontSize);

			var textSize = graphics.MeasureString(tag.Word, font);
			var res = _cloudLayouter.PutNextRectangle(new Size((int)textSize.Width, (int)textSize.Height), rectangels);
			tag.Location = new Point(res.X, res.Y);
		}

		graphics.Dispose();

		return tags;
	}
}