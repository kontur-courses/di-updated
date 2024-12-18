using FakeItEasy;
using FluentAssertions;
using TagsCloudContainer.TagsCloudVisualization.Logic.SizeCalculators;
using TagsCloudContainer.TagsCloudVisualization.Models.Settings;
using TagsCloudContainer.TagsCloudVisualization.Providers.Interfaces;

namespace TagsCloudContainer.Tests.TagsCloudVisualization;

[TestFixture]
[TestOf(typeof(WeigherWordSizer))]
public partial class WeigherWordSizerTests
{
    private IImageSettingsProvider imageSettingsProvider;

    [SetUp]
    public void SetUp()
    {
        var imageSettings = new ImageSettings();
        imageSettingsProvider = A.Fake<IImageSettingsProvider>();
        A.CallTo(() => imageSettingsProvider.GetImageSettings()).Returns(imageSettings);
    }

    [Test]
    [TestCaseSource(nameof(emtyResultCases))]
    public void CalculateWordSizes_HandlesEmptyDictionary_ReturnsEmptyCollection(
        IReadOnlyDictionary<string, int> wordFrequencies)
    {
        var calculator = new WeigherWordSizer(imageSettingsProvider);
        var result = calculator.CalculateWordSizes(wordFrequencies);
        result.Should().BeEmpty();
    }

    [Test]
    [TestCaseSource(nameof(validWordCountsCases))]
    public void CalculateWordSizes_CalculatesCorrectSizes_ForMultipleWords(
        IReadOnlyDictionary<string, int> wordFrequencies)
    {
        var calculator = new WeigherWordSizer(imageSettingsProvider);
        var expectedWordOrder = wordFrequencies.OrderByDescending(x => x.Value).Select(x => x.Key);

        var result = calculator.CalculateWordSizes(wordFrequencies);
        var resultWordOrder = result.OrderByDescending(w => w.Font.Size).Select(w => w.Word);

        resultWordOrder.Should().BeEquivalentTo(expectedWordOrder);
    }

    [Test]
    [TestCaseSource(nameof(customMinMaxSizeCases))]
    public void CalculateWordSizes_UsesCustomMinMaxSizes(IReadOnlyDictionary<string, int> wordFrequencies, int minSize,
        int maxSize)
    {
        var calculator = new WeigherWordSizer(imageSettingsProvider);
        var result = calculator.CalculateWordSizes(wordFrequencies, minSize, maxSize);
        _ = result.Select(x => x.Font.Size.Should().BeInRange(minSize, maxSize));
    }

    [Test]
    [TestCaseSource(nameof(customMinMaxSizeCases))]
    public void CalculateWordSizes_AssignsMaxSize(IReadOnlyDictionary<string, int> wordFrequencies, int minSize,
        int maxSize)
    {
        var calculator = new WeigherWordSizer(imageSettingsProvider);

        var result = calculator.CalculateWordSizes(wordFrequencies, minSize, maxSize);
        var maxWordSize = (int) result.Max(w => w.Font.Size);

        maxWordSize.Should().Be(maxSize);
    }
}