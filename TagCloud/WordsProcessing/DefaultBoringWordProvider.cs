namespace TagCloud.WordsProcessing;

public class DefaultBoringWordProvider : IBoringWordProvider
{
	public string[] GetBoringWords()
	{
		return ["в", "на"];
	}
}