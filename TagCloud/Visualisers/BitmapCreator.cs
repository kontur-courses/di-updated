using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud.Visualisers
{
    public class BitmapCreator : IBitmapCreator
    {
        public static Bitmap GenerateImage(IEnumerable<TagCloudWord> cloudWords, ImageSettings settings)
        {
            var bitmap = new Bitmap(settings.ImageSize.Width, settings.ImageSize.Height);

            using var graphics = Graphics.FromImage(bitmap);
            graphics.Clear(settings.BackgroundColor);
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            using var brush = new SolidBrush(settings.WordColor);

            foreach (var tagWord in cloudWords)
            {
                using var font = new Font(settings.FontFamily, tagWord.FontSize);
                
                graphics.DrawString(tagWord.TextWord, font, brush, tagWord.Box.Location);
            }

            return bitmap;
        }
    }
}
