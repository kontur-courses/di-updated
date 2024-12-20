using System.Drawing;

namespace TagsCloudVisualization.Settings;

public record BitmapGeneratorSettings(
    Size ImageSize,
    Color Background,
    Color WordsColor,
    FontFamily FontFamily);