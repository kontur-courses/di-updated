using System.Net;
using System.Text.Json;
using FractalPainting.Application.Fractals;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;

namespace FractalPainting.Application.Actions;

public class DragonFractalAction(IDragonPainterFactory dragonPainterFactory) : IApiAction
{
    private readonly JsonSerializerOptions jsonSerializerOptions =
        new() { Converters = { new FigureJsonConverter() } };

    public string Endpoint => "/dragonFractal";

    public string HttpMethod => "POST";

    public int Perform(Stream inputStream, Stream outputStream)
    {
        var dragonSettings = JsonSerializer.Deserialize<DragonSettings>(inputStream);
        var dragonPainter = dragonPainterFactory.Create(dragonSettings!);
        var figures = dragonPainter.Paint();
        JsonSerializer.Serialize(outputStream, figures, options: jsonSerializerOptions);

        return (int)HttpStatusCode.OK;
    }
}