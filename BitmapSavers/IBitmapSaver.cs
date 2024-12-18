using System.Drawing;

namespace BitmapSavers
{
    public interface IBitmapSaver
    {
        public string Save(Bitmap bitmap, string path);
    }
}
