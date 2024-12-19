namespace TagCloud;

public interface IRectanglesGenerator
{
    public List<WordInShape> GetWordsInShape(IEnumerable<string> words);
}