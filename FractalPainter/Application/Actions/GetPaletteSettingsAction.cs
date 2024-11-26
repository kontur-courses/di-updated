using System.Net;
using System.Text.Json;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;

namespace FractalPainting.Application.Actions;

public class GetPaletteSettingsAction(Palette palette) : IApiAction
{
    public string Endpoint => "/palette";
        
    public string HttpMethod => "GET";
        
    public int Perform(Stream inputStream, Stream outputStream)
    {
        JsonSerializer.Serialize(outputStream, palette);
        return (int)HttpStatusCode.OK;
    }
}