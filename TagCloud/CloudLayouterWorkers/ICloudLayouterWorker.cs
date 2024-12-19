using System.Drawing;

namespace TagCloud.CloudLayouterWorkers
{
    // Интерфейс получения размера следующего прямоугольника
    internal interface ICloudLayouterWorker
    {
        public IEnumerable<Size> GetNextRectangleSize(int rectanglesCount);
    }
}
