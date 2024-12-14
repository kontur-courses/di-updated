using System.Drawing;

namespace TagCloud.WordRenderer;

public class WordRenderSizeProviderImpl : IWordRenderSizeProvider
{
    private Size _minSize = Size.Empty;
    private Size _maxSize = new Size(20, 40);
    
    public Size GetWordRenderSize(double frequency)
    {
        if (frequency < 0 || frequency > 1)
            throw new ArgumentOutOfRangeException(nameof(frequency), "must be between 0 and 1");
        
        var width = (int)Math.Round((_maxSize.Width - _minSize.Width) * frequency);
        var height = (int)Math.Round((_maxSize.Height - _minSize.Height) * frequency);
        return new Size(width, height);
    }
}