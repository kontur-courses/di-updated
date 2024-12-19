using System.Drawing;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudContainer;
using TagsCloudVisualization;

namespace TagsCloudVisualizationTest;

public class LayoutGeneratorTests
{
    private TagCloudGenerator generator;
    private Point center;
    private Size imageSize;
    private string outputDirectory;

    [SetUp]
    public void Setup()
    {
        center = new Point(0, 0);
        imageSize = new Size(800, 600);

        var pointGenerator = new SpiralGenerator(center);
        var layouter = new CircularCloudLayouter(pointGenerator);
        var renderer = new CloudImageRenderer();
        var boringWords = new[] { "a", "the", "is", "and" };
        var wordProcessor = new WordProcessor(boringWords);

        generator = new TagCloudGenerator(wordProcessor, layouter, renderer);

        outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "TestOutputs");
        Directory.CreateDirectory(outputDirectory);
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(outputDirectory))
            Directory.Delete(outputDirectory, true);
    }

    [Test]
    public void GenerateCloud_ShouldCreateImageFile()
    {
        var inputFilePath = Path.Combine(outputDirectory, "input.txt");
        var outputFilePath = Path.Combine(outputDirectory, "layout_test.png");

        File.WriteAllLines(inputFilePath, new[] { "word", "cloud", "test", "word", "cloud", "test", "test" });

        generator.GenerateCloud(inputFilePath, outputFilePath, imageSize);

        File.Exists(outputFilePath).Should().BeTrue("файл изображения должен быть создан");
    }

    [Test]
    public void GenerateCloud_ShouldPlaceCorrectNumberOfTags()
    {
        var inputFilePath = Path.Combine(outputDirectory, "input.txt");
        var outputFilePath = Path.Combine(outputDirectory, "layout_test.png");
        
        File.WriteAllLines(inputFilePath, new[] { "word", "cloud", "test", "word", "cloud", "test", "test" });

        generator.GenerateCloud(inputFilePath, outputFilePath, imageSize);

        var pointGenerator = new SpiralGenerator(center);
        var layouter = new CircularCloudLayouter(pointGenerator);

        var words = File.ReadAllLines(inputFilePath);
        var wordFrequencies = words.GroupBy(w => w).ToDictionary(g => g.Key, g => g.Count());

        foreach (var frequency in wordFrequencies.Values)
        {
            var size = new Size(frequency * 10, frequency * 10);
            layouter.PutNextRectangle(size);
        }

        var generatedRectangles = layouter.GetRectangles().ToList();
        generatedRectangles.Count.Should().Be(wordFrequencies.Count, "должно быть сгенерировано правильное количество тегов");
    }
}
