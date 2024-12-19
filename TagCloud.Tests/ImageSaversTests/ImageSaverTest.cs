using System.Drawing;
using TagCloud.ImageSavers;

namespace TagCloud.Tests.ImageSaversTests
{
    [TestFixture]
    internal class ImageSaverTest
    {
        private string directoryPath = "TempFilesForImageSaverTests";
        private ImageSaver imageSaver;

        [OneTimeSetUp]
        public void Init()
        {
            Directory.CreateDirectory(directoryPath);
        }

        [SetUp]
        public void SetUp()
        {
            imageSaver = new ImageSaver();
        }

        [TestCase("Test.png")]
        public void SaveFile_ArgumentNullException_WithNullBitmap(string filename)
        {
            var path = Path.Combine(directoryPath, filename);
            Assert.Throws<ArgumentNullException>(() => imageSaver.SaveFile(null, path));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SaveFile_ThrowsArgumentException_WithInvalidFilename(string? filename)
        {
            var dummyImage = new Bitmap(1, 1);
            Assert.Throws<ArgumentException>(() => imageSaver.SaveFile(dummyImage, filename));
        }

        [TestCase("Test.png", ExpectedResult = true)]
        public bool SaveFile_SavesFile(string filename)
        {
            var dummyImage = new Bitmap(1, 1);
            var path = Path.Combine(directoryPath, filename);

            File.Delete(path);
            imageSaver.SaveFile(dummyImage, path);
            return File.Exists(path);
        }


        [OneTimeTearDown]
        public void OneTimeCleanup()
        {
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }
        }
    }
}
