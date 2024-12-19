using System.Drawing;

namespace TagCloud.CloudLayouterWorkers
{
    internal class FrequencyBasedCloudLayouterWorker(
        int minRectangleWidth,
        int maxRectangleWidth,
        int minRectangleHeight,
        int maxRectangleHeight,
        Dictionary<string, double> normalizedValues) : ICloudLayouterWorker
    {
        public IEnumerable<Size> GetNextRectangleSize(int rectanglesCount)
        {
            throw new NotImplementedException();
        }
    }
}
