using System.Drawing;
using TagCloud.Settings;

namespace TagCloud.TagPositioner.Circular;

public class CircularCloudLayouter : ICloudLayouter
{
	private readonly ISettingsProvider _settingsProvider;
	private Point center;
	private double angle;
	private const double SpiralStep = 0.2;
	private double angleStep = 0.01;

	public CircularCloudLayouter(ISettingsProvider settingsProvider)
	{
		_settingsProvider = settingsProvider;

	}

	public Rectangle PutNextRectangle(Size rectangleSize, ICollection<Rectangle> rectangles)
	{
		center = new Point(_settingsProvider.GetSettings().Width /2 , _settingsProvider.GetSettings().Height /2);
		Rectangle newRectangle;
		if (!rectangles.Any())
		{
			var rectangle = new Rectangle(center, rectangleSize);
			rectangles.Add(rectangle);
			return rectangle;
		}

		do
		{
			var location = GetLocation(rectangleSize);
			newRectangle = new Rectangle(location, rectangleSize);
		}
		while (rectangles.IsIntersecting(newRectangle));

		rectangles.Add(newRectangle);

		return newRectangle;
	}

	private Point GetLocation(Size rectangleSize)
	{
		var radius = SpiralStep * angle;
		var x = (int)(center.X + radius * Math.Cos(angle) - rectangleSize.Width / 2);
		var y = (int)(center.Y + radius * Math.Sin(angle) - rectangleSize.Height / 2);
		angle += angleStep;

		return new Point(x, y);
	}
}