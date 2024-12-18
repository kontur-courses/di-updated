using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud.Visualisers
{
    public class TagCloudWord(Rectangle box, string textWord, int fontSize)
    {
        public readonly Rectangle Box = box;

        public readonly string TextWord = textWord;

        public readonly int FontSize = fontSize;
    }
}
