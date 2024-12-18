using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TagCloud.Interfaces;
using TagCloud.Visualisers;

namespace TagCloud
{
    public class TagCloudCreator
    {
        public readonly ICloudLayouter Layouter;
        
        public TagCloudCreator(ICloudLayouter layouter)
        {
            Layouter = layouter;
        }

        public Bitmap CreateTagCloudBitmap(Dictionary<string, int> wordFreqDictionary, ImageSettings settings)
        {
            throw new NotImplementedException();
        }

        private int TransformFreqToSize(int minFontSize, int maxFontSize, int freq, int maxFreq)
        {
            return (int)(minFontSize + ((float) freq / maxFreq * (maxFontSize - minFontSize)));
        }
    }
}
