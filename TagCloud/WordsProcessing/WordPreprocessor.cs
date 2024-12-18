using TagCloud.Settings;
using TagCloud.WordsReader;

namespace TagCloud.WordsProcessing;

public class WordPreprocessor : IWordPreprocessor
{
	private readonly IBoringWordProvider _boringWordProvider;
	private readonly IWordsReader _wordsReader;
	private readonly ISettingsProvider _settingsProvider;

	public WordPreprocessor(IBoringWordProvider boringWordProvider, IWordsReader wordsReader, ISettingsProvider settingsProvider)
	{
		_boringWordProvider = boringWordProvider;
		_wordsReader = wordsReader;
		_settingsProvider = settingsProvider;
	}
	public IEnumerable<string> Process()
	{
		var strings = _wordsReader.Read(_settingsProvider.GetSettings().SourcePath);
		return strings
			.Select(x => x.ToLower())
			.Where(x => !_boringWordProvider.GetBoringWords().Contains(x));
	}
}