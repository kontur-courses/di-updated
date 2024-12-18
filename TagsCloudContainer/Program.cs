using Autofac;
using TagsCloudContainer;
using TagsCloudContainer.Layouters;
using TagsCloudContainer.Renderers;
using TagsCloudContainer.TextProviders.Factory;
using TagsCloudContainer.WordsPreprocessor;

var builder = new ContainerBuilder();

builder.RegisterType<App>();
builder.RegisterType<CircularCloudLayouter>().As<ILayouter>();
builder.RegisterType<SimpleRenderer>().As<IRenderer>();
builder.RegisterType<AppConfig>().SingleInstance();
builder.RegisterType<WordsPreprocessor>().As<IWordsPreprocessor>().SingleInstance();
builder.RegisterType<WordsProviderFactory>().As<IWordsProviderFactory>().SingleInstance();

var container  = builder.Build();

var app = container.Resolve<App>();
app?.Run();