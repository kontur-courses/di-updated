using System.Drawing;

namespace TagCloud.ImageSavers
{
    internal class ImageSaver : IImageSaver
    {
        public void SaveFile(Bitmap image, string fileName)
        {
            if (image is null)
            {
                throw new ArgumentNullException("Передаваемое изображение не должно быть null");
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("Некорректное имя файла для создания");
            }

            image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
