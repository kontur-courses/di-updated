using Autofac;
using TagsCloudContainer.ConsoleUi;
using TagsCloudContainer.ConsoleUi.Runner.Interfaces;
using TagsCloudContainer.TagsCloudVisualization;
using TagsCloudContainer.TextAnalyzer;

var builder = new ContainerBuilder();
builder.RegisterModule(new TextAnalyzerModule());
builder.RegisterModule(new TagsCloudVisualizationModule());
builder.RegisterModule(new ConsoleClientModule());

var app = builder.Build();
using var scope = app.BeginLifetimeScope();
var appRunner = scope.Resolve<ITagsCloudContainerUi>();
appRunner.Run();