using System.Drawing;

namespace TagCloud;

public class WordInShape
{
    public readonly string Word;
    public readonly Rectangle Rectangle;

    WordInShape(string word, Rectangle rectangle)
    {
        Word = word;
        Rectangle = rectangle;
    }
}