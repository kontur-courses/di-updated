namespace TagCloud.Client;

public class GuiClient : IClient
{
	private readonly App _app;

	public GuiClient(App app)
	{
		_app = app;
	}
	public void Run()
	{
		Console.WriteLine("This is GUI Application");
		throw new NotImplementedException();
	}
}