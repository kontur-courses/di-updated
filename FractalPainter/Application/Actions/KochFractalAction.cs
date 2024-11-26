using System.Net;
using System.Text.Json;
using FractalPainting.Application.Fractals;
using FractalPainting.Infrastructure.UiActions;

namespace FractalPainting.Application.Actions;

public class KochFractalAction(KochPainter kochPainter) : IApiAction
{
    private readonly JsonSerializerOptions jsonSerializerOptions =
        new() { Converters = { new FigureJsonConverter() } };

    public string Endpoint => "/kochFractal";

    public string HttpMethod => "POST";

    public int Perform(Stream inputStream, Stream outputStream)
    {
        var figures = kochPainter.Paint();
        JsonSerializer.Serialize(outputStream, figures, options: jsonSerializerOptions);
        return (int)HttpStatusCode.OK;
    }
}