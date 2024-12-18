using System.Collections.Immutable;

namespace TagsCloudContainer.Tests.TagsCloudVisualization;

public partial class WeigherWordSizerTests
{
    private static readonly IEnumerable<TestCaseData> customMinMaxSizeCases =
    [
        new TestCaseData(new Dictionary<string, int> {{"test", 10}}, 10, 30).SetName("Min10Max30"),
        new TestCaseData(new Dictionary<string, int> {{"test", 100}, {"another", 50}}, 5, 25).SetName("Min5Max25"),
    ];

    private static readonly IEnumerable<TestCaseData> validWordCountsCases =
    [
        new TestCaseData(new Dictionary<string, int> {{"test", 1}}).SetName("OneWord"),
        new TestCaseData(new Dictionary<string, int> {{"test", 10}}).SetName("OneWordType"),
        new TestCaseData(new Dictionary<string, int> {{"test", 100}, {"another", 50}}).SetName("MoreWords"),
    ];

    private static readonly IEnumerable<TestCaseData> emtyResultCases =
    [
        new TestCaseData(new Dictionary<string, int> {{"test", -1}}).SetName("InvalidWordCount"),
        new TestCaseData(new Dictionary<string, int> {{"test", 0}}).SetName("ZeroWordCount"),
        new TestCaseData(ImmutableDictionary<string, int>.Empty).SetName("Empty"),
    ];
}