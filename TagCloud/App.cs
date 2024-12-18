using System.Drawing;
using TagCloud.CloudPainter;
using TagCloud.Settings;
using TagCloud.TagPositioner;
using TagCloud.TagPositioner.Circular;
using TagCloud.WordCounter;
using TagCloud.WordsProcessing;
using TagCloud.WordsReader;

namespace TagCloud;

public class App
{
	private readonly IWordPreprocessor _wordPreprocessor;
	private readonly IWordCounter _wordCounter;
	private readonly ICloudPainter _cloudPainter;
	private readonly ITagPositioner _tagPositioner;

	public App(IWordPreprocessor wordPreprocessor,
		IWordCounter wordCounter,
		ICloudPainter cloudPainter,
		ITagPositioner tagPositioner)
	{
		_wordPreprocessor = wordPreprocessor;
		_wordCounter = wordCounter;
		_cloudPainter = cloudPainter;
		_tagPositioner = tagPositioner;
	}

	public void Run()
	{
		var words = _wordPreprocessor.Process().ToArray();
		var tags = _wordCounter.CalculateWordCount(words);
		tags = _tagPositioner.Position(tags);
		_cloudPainter.Paint(tags);
	}
}