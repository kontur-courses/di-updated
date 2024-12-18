using TagsCloudContainer.ConsoleUi.Options.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Handlers.Interfaces;

public interface IHandler
{
    public bool TryExecute(IOptions options, out string result);
}