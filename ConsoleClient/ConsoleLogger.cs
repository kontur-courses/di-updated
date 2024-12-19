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
        var oldColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"WARNING: {message}");
        Console.ForegroundColor = oldColor;
    }

    public void Error(string message)
    {
        var oldColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR: {message}");
        Console.ForegroundColor = oldColor;
    }

    public void ReportProgress(string message, double progress)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(progress);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(progress, 1);
        var progressPercentage = (int)(progress * 100.0);
        var (left, top) = Console.GetCursorPosition();
        Console.Write($"{message}: [");
        for (var i = 0; i <= 10; i++)
        {
            if (i <= progressPercentage / 10)
                Console.Write('=');
            else
                Console.Write(' ');
        }
        Console.WriteLine(']');
        
        if (progressPercentage < 100)
            Console.SetCursorPosition(left, top);
    }
}