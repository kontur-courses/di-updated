using System.Drawing;

namespace TagsCloudVisualization.Interfaces;

public interface ITagCloudGenerator
{
    void GenerateCloud(string inputFilePath, string outputFilePath, Size imageSize);
}