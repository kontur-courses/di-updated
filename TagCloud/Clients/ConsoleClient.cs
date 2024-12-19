using TagCloud.CloudDrawer;

namespace TagCloud.Clients;

public class ConsoleClient
{
    public List<string> Commands { get; set; } = new List<string>();

    private bool TryGetFileFromConsole(out string filePath)
    {
        throw new NotImplementedException();
    }

    private bool TryGetImageSettingsFromConsole(out string filePath)
    {
        throw new NotImplementedException();
    }

    public DrawerSettings GetDrawerSettings()
    {
        throw new NotImplementedException();
    }
}