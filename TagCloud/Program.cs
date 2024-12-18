using Autofac;
using TagCloud.Client;
using TagCloud.CloudPainter;
using TagCloud.Settings;
using TagCloud.TagPositioner;
using TagCloud.TagPositioner.Circular;
using TagCloud.WordCounter;
using TagCloud.WordsProcessing;
using TagCloud.WordsReader;

namespace TagCloud;

class Program
{
	static void Main()
	{
		var builder = new ContainerBuilder();

		builder.RegisterType<App>();
		builder.RegisterType<TxtWordsReader>().As<IWordsReader>();
		builder.RegisterType<WordPreprocessor>().As<IWordPreprocessor>();
		builder.RegisterType<WordCounter.WordCounter>().As<IWordCounter>();
		builder.RegisterType<DefaultBoringWordProvider>().As<IBoringWordProvider>();
		builder.RegisterType<ConsoleClient>().As<IClient>();
		builder.RegisterType<SettingsProvider>().As<ISettingsProvider>().SingleInstance();
		builder.RegisterType<CloudPainter.CloudPainter>().As<ICloudPainter>();
		builder.RegisterType<CircularCloudLayouter>().As<ICloudLayouter>();
		builder.RegisterType<TagPositioner.TagPositioner>().As<ITagPositioner>();

		var container = builder.Build();

		var app = container.Resolve<IClient>();

		app.Run();
	}
}