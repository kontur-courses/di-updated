using CommandLine;
using TagCloud.Settings;

namespace TagCloud.Client;

public class ConsoleClient : IClient
{
	private readonly App _app;
	private readonly ISettingsProvider _settingsProvider;

	public ConsoleClient(App app, ISettingsProvider settingsProvider)
	{
		_app = app;
		_settingsProvider = settingsProvider;
	}
	public void Run()
	{
		Console.WriteLine("This is console Application.");

		var args = Environment.GetCommandLineArgs();

		//TODO:Получать аргументы из командной строки:
		// 1. Ширина
		// 2. Высота
		// 3. Путь к файлу со словами
		// 4. Путь к папке сохранения результат
		// 5. Путь к файлу со "скучными словами".
		// 6. Алгоритм построения облака
		// 6.1 Алгоритм расцветки?
		// 6.2 Алгоритм построения?

		//TODO: Задавать размер шрифта - минимум и максимум. Чем чаще встречается слово - тем больше шрифт.
		var settings = _settingsProvider.GetSettings();
		settings.SourcePath = "words.txt";
		settings.SavePath = "..\\..\\..\\result.png";
		settings.Width = 800;
		settings.Height = 800;
		settings.FontFamily = "Consolas";

		_settingsProvider.SetSettings(settings);

		Parser.Default.ParseArguments<Settings.Settings>(args)
			.WithParsed(settings =>
			{


			});

		_app.Run();
	}
}