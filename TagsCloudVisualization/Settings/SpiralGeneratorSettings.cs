using System.Drawing;

namespace TagsCloudVisualization.Settings;

public class SpiralGeneratorSettings(double angleOffset, double spiralStep, Point center)
{
    public double AngleOffset { get; private set; } = angleOffset;
    public double SpiralStep { get; private set; } = spiralStep;
    public Point Center { get; private set; } = center;
}