namespace TagCloud.WordsProcessing;

public interface IWordPreprocessor
{
	IEnumerable<string> Process();
}