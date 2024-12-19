namespace TagCloud.WordCounter;

public interface IWordCounter
{
	List<Tag> CalculateWordCount(IEnumerable<string> words);
}