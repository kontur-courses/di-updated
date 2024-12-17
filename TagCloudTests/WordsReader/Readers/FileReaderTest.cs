using System.Text;
using FluentAssertions;
using TagCloud.WordsReader;
using TagCloud.WordsReader.Readers;

namespace TagCloudTests.WordsReader.Readers;

[TestFixture]
[TestOf(typeof(FileReader))]
public class FileReaderTest
{
    private const string FilePath = "Samples/text.txt";

    [Test]
    public void FileReader_ReadWords_ShouldReadAllWords()
    {
        var reader = new FileReader(FilePath, Encoding.UTF8);
        var fileContent = File.ReadAllLines(FilePath, Encoding.UTF8).ToText(" ");

        var words = reader.ReadWords();

        words.ToText(" ").Should().Be(fileContent);
    }
}