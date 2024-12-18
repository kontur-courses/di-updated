using Autofac;
using Microsoft.Extensions.Configuration;
using MyStemWrapper;
using TagsCloudContainer.TextAnalyzer.Logic.Analyzers;
using TagsCloudContainer.TextAnalyzer.Logic.Analyzers.Interfaces;
using TagsCloudContainer.TextAnalyzer.Logic.Filters;
using TagsCloudContainer.TextAnalyzer.Logic.Filters.Interfaces;
using TagsCloudContainer.TextAnalyzer.Logic.Formatters;
using TagsCloudContainer.TextAnalyzer.Logic.Formatters.Interfaces;
using TagsCloudContainer.TextAnalyzer.Logic.Preprocessors;
using TagsCloudContainer.TextAnalyzer.Logic.Preprocessors.Interfaces;
using TagsCloudContainer.TextAnalyzer.Logic.Readers;
using TagsCloudContainer.TextAnalyzer.Logic.Readers.Interfaces;
using TagsCloudContainer.TextAnalyzer.Models;
using TagsCloudContainer.TextAnalyzer.Providers;
using TagsCloudContainer.TextAnalyzer.Providers.Interfaces;

namespace TagsCloudContainer.TextAnalyzer;

public class TextAnalyzerModule() : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        var myStemSettings = configuration.GetSection("MyStem").Get<StemSettings>();
        if (myStemSettings == null || string.IsNullOrEmpty(myStemSettings.Path))
        {
            throw new ArgumentException("Настройки MyStem не найдены или неполны в appsettings.json");
        }

        builder.Register(_ => new MyStem()
        {
            PathToMyStem = $"{myStemSettings.Path}",
            Parameters = $"{myStemSettings.Parameters}",
        }).SingleInstance();

        builder.RegisterType<FileTextReader>().As<IFileTextReader>();
        builder.RegisterType<WordAnalyzer>().As<IWordAnalyzer<WordDetails>>();
        builder.RegisterType<WordCaseFormatter>().As<IWordFormatter<WordDetails>>();
        builder.RegisterType<WordFilter>().As<IWordFilter<WordDetails>>();
        builder.RegisterType<WordReader>().As<IWordReader>();
        builder.RegisterType<WordSettingsProvider>().As<IWordSettingsProvider>().SingleInstance();
        builder.RegisterType<TextPreprocessor>().As<ITextPreprocessor>();
    }
}