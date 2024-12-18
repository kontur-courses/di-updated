using FluentAssertions;
using TagsCloudContainer;
using TagsCloudContainer.TextProviders.Factory;

namespace TagsCloudTest;

public class WordsProviderTests
{
    [Test]
    public void GetWords_ReturnSeparatedWordsFromTxt()
    {
        var appConfig = new AppConfig
        {
            TextFilePath = "./ProviderTest.txt"
        };
        var factory = new WordsProviderFactory(appConfig);
        var provider = factory.CreateProvider(appConfig.TextFilePath);
        
        provider.GetWords()
            .Should()
            .BeEquivalentTo(["a", "b", "c", "a", "b", "c"]);
    }
    
    [Test]
    public void GetWords_ReturnSeparatedWordsFromDocx()
    {
        var appConfig = new AppConfig
        {
            TextFilePath = "./docx.docx"
        };
        var factory = new WordsProviderFactory(appConfig);
        var provider = factory.CreateProvider(appConfig.TextFilePath);
        
        provider.GetWords()
            .Should()
            .BeEquivalentTo(["очень", "маленький", "тестовый", "файл", "для", "docx"]);
    }

    [Test]
    public void CreateProvider_ThrowExceptionIfFileDoesNotExist()
    {
        var appConfig = new AppConfig
        {
            TextFilePath = "./DoNotExist.txt"
        };
        var provider = new WordsProviderFactory(appConfig);
        
        var act = () => provider.CreateProvider(appConfig.TextFilePath);
        
        act.Should().Throw<FileNotFoundException>($"The file '{appConfig.TextFilePath}' was not found");
    }
    
    [Test]
    public void CreateProvider_ThrowExceptionIfNonTxtFile()
    {
        var appConfig = new AppConfig
        {
            TextFilePath = "./Autofac.dll"
        };
        var provider = new WordsProviderFactory(appConfig);
        
        var act = () => provider.CreateProvider(appConfig.TextFilePath);
        
        act.Should().Throw<InvalidOperationException>($"Unsupported file type: {Path.GetExtension(appConfig.TextFilePath)}");
    }
    
    [Test]
    public void CreateProvider_ThrowExceptionIfPathDoesNotExist()
    {
        var appConfig = new AppConfig
        {
            TextFilePath = ""
        };
        var provider = new WordsProviderFactory(appConfig);
        
        var act = () => provider.CreateProvider(appConfig.TextFilePath);
        
        act.Should().Throw<ArgumentNullException>(nameof(appConfig.TextFilePath), "Text file path is not provided");
    }
}