using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud.Visualisers
{
    public interface IBitmapCreator
    {
        public static abstract Bitmap GenerateImage(IEnumerable<TagCloudWord> cloudWords, ImageSettings settings);
    }
}
