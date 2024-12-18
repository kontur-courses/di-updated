using TagsCloudContainer.ConsoleUi.Handlers.Interfaces;
using TagsCloudContainer.ConsoleUi.Options;
using TagsCloudContainer.ConsoleUi.Options.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Handlers;

public class ExitHandler : IHandlerT<ExitOptions>
{
    public bool TryExecute(IOptions options, out string result)
    {
        if (options is ExitOptions exitOptions)
        {
            result = Execute(exitOptions);
            return true;
        }

        result = string.Empty;
        return false;
    }

    public string Execute(ExitOptions options)
    {
        Environment.Exit(0);
        return "Завершение";
    }
}