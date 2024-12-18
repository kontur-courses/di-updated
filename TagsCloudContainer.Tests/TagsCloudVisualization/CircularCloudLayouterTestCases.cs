using System.Drawing;

namespace TagsCloudContainer.Tests.TagsCloudVisualization;

public partial class CircularCloudLayouterTests
{
    private static readonly IEnumerable<TestCaseData> zeroSizeCases =
    [
        new TestCaseData(new Size(0, 0))
            .SetName("AllZero"),
        new TestCaseData(new Size(1, 0))
            .SetName("WidthZero"),
        new TestCaseData(new Size(0, 1))
            .SetName("HeightZero"),
    ];

    private static readonly IEnumerable<TestCaseData> unusualRectangleSizeCases =
    [
        new TestCaseData(Array.Empty<Size>())
            .SetName("ArraySizeEmpty"),
    ];

    private static readonly IEnumerable<TestCaseData> validRectangleSizeCases =
    [
        new TestCaseData(new List<Size>() {new(10, 10)})
            .SetName("OneSize"),
        new TestCaseData(new List<Size>() {new(10, 10), new(20, 20), new(15, 15), new(5, 7), new(3, 1), new(15, 35)})
            .SetName("MoreSizes"),
    ];
}