using System.Drawing;
using System.Runtime.CompilerServices;
using TagCloud.CloudLayouterPainters;
using TagCloud.CloudLayouters.CircularCloudLayouter;
using TagCloud.CloudLayouterWorkers;
using TagCloud.ImageSavers;
using TagCloud.Normalizers;
using TagCloud.WordCounters;
using TagCloud.WordFilters;
using TagCloud.WordReaders;

[assembly: InternalsVisibleTo("TagCloud.Tests")]
namespace TagCloud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartOldVariant();
        }

        // Пример работы со старого задания TagCloud
        private static void StartOldVariant()
        {
            var center = new Point(400, 400);
            var minRectangleWidth = 30;
            var maxRectangleWidth = 70;
            var minRectangleHeight = 20;
            var maxRectangleHeight = 50;
            var rectanglesCount = 1000;
            var imageFileName = "Result.png";

            var rectangles = new List<Rectangle>();
            var circularCloudLayouter = new CircularCloudLayouter(center);

            var randomWorker = new RandomCloudLayouterWorker(
                minRectangleWidth,
                maxRectangleWidth,
                minRectangleHeight,
                maxRectangleHeight);

            foreach (var rectangleSize in randomWorker.GetNextRectangleSize(rectanglesCount))
            {
                rectangles.Add(circularCloudLayouter.PutNextRectangle(rectangleSize));
            }

            var painter = new CloudLayouterPainter();
            var imageSaver = new ImageSaver();
            imageSaver.SaveFile(painter.Draw(rectangles), imageFileName);
        }

        // Пример работы с новым вариантом
        private static void StartNewVariant()
        {
            var center = new Point(400, 400);
            var minRectangleWidth = 30;
            var maxRectangleWidth = 70;
            var minRectangleHeight = 20;
            var maxRectangleHeight = 50;

            var imageFileName = "Result.png";
            var dataFileName = "Values.txt";

            var wordReader = new WordReader();
            var wordFilter = new WordFilter();
            var wordCounter = new WordCounter();

            foreach (var word in wordReader.ReadByLines(dataFileName))
            {
                if (!wordFilter.IsCorrectWord(word))
                {
                    continue;
                }
                wordCounter.AddWord(word);
            }

            var normalizer = new Normalizer();
            var normalizedWordCounts = normalizer.Normalize(wordCounter.Counts);

            var circularCloudLayouter = new CircularCloudLayouter(center);
            var frequencyBasedCloudLayouterWorker =
                new FrequencyBasedCloudLayouterWorker(
                    minRectangleWidth,
                    maxRectangleWidth,
                    minRectangleHeight,
                    maxRectangleHeight,
                    normalizedWordCounts);

            // Начиная с этого места,
            // в дальнейшем нужно будет использовать
            // Tag вместо Rectangle.
            // В черновом варианте не переделывал,
            // что бы не ломать старые написанные тесты. 
            var rectangles = new List<Rectangle>();
            foreach (var rectangleSize in frequencyBasedCloudLayouterWorker
                .GetNextRectangleSize(wordCounter.Counts.Count))
            {
                rectangles.Add(circularCloudLayouter.PutNextRectangle(rectangleSize));
            }

            var painter = new CloudLayouterPainter();
            var imageSaver = new ImageSaver();
            imageSaver.SaveFile(painter.Draw(rectangles), imageFileName);
        }
    }
}
