namespace TagCloud.WordCounter;

public class WordCounter : IWordCounter
{
	public List<Tag> CalculateWordCount(IEnumerable<string> words)
	{
		//TODO: Добавить нормализацию или алгоритм нормализации.
		return words.GroupBy(x => x)
			.Select(x => new Tag(){ Word = x.Key, Count = x.Count() })
			.ToList();
	}
}