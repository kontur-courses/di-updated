using TagsCloudContainer.ConsoleUi.Options.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Handlers.Interfaces;

public interface IHandlerT<in TOptions> : IHandler
    where TOptions : IOptions
{
    public string Execute(TOptions options);
}