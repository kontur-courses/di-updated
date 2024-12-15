using TagCloud.Logger;

namespace ConsoleClient;

public class ConsoleLogger : ILogger
{
    public void Info(string message)
    {
        Console.WriteLine($"INFO: {message}");
    }

    public void Warning(string message)
    {
        Console.WriteLine($"WARNING: {message}", ConsoleColor.Yellow);
    }

    public void Error(string message)
    {
        Console.WriteLine($"ERROR: {message}", ConsoleColor.Red);
    }
}