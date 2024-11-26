using System.Net;
using System.Text.Json;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;

namespace FractalPainting.Application.Actions;

public class UpdateImageSettingsAction(IImageSettingsProvider imageSettingsProvider) : IApiAction
{
    public string Endpoint => "/settings";
    public string HttpMethod => "PUT";

    public int Perform(Stream inputStream, Stream outputStream)
    {
        var updatedSettings = JsonSerializer.Deserialize<ImageSettings>(inputStream);
        var settings = imageSettingsProvider.ImageSettings;
        settings.Height = updatedSettings?.Height ?? settings.Height;
        settings.Width = updatedSettings?.Width ?? settings.Width;
        JsonSerializer.Serialize(outputStream, settings);

        return (int)HttpStatusCode.OK;
    }
}