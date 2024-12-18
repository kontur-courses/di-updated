using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud.Visualisers
{
    public record ImageSettings(
        Size ImageSize, 
        Color BackgroundColor, 
        FontFamily FontFamily, 
        int FontMinSize,
        int FontMaxSize,
        Color WordColor);
}
