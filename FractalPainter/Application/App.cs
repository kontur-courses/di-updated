using System.Net;
using System.Text.Json;
using FractalPainting.Application.Models;
using FractalPainting.Infrastructure.UiActions;

namespace FractalPainting.Application;

internal sealed class App
{
    private const string Endpoint = "http://localhost:8080/";
    private readonly HttpListener httpListener;
    private readonly IReadOnlyDictionary<string, IApiAction> routeActions;

    public App(IEnumerable<IApiAction> actions)
    {
        var actionsArray = actions.ToArray();
        httpListener = new HttpListener();
        httpListener.Prefixes.Add(Endpoint);
        routeActions = actionsArray.ToDictionary(action => $"{action.HttpMethod} {action.Endpoint}", action => action);
    }

    public async Task Run()
    {
        httpListener.Start();
        Console.WriteLine($"Listening at {Endpoint}");
        while (true)
        {
            var context = await httpListener.GetContextAsync();
            
            // Обработка запроса
            try
            {
                var actionKey = $"{context.Request.HttpMethod} {context.Request.Url!.AbsolutePath}";

                if (actionKey == "GET /")
                {
                    context.Response.ContentType = "text/html";
                    await using var fileStream = File.OpenRead(Path.Join(".", "static", "index.html"));
                    await fileStream.CopyToAsync(context.Response.OutputStream);
                    continue;
                }

                if (!routeActions.TryGetValue(actionKey, out var action))
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    context.Response.Close();
                    continue;
                }

                action.Perform(context.Request.InputStream, context.Response.OutputStream);
            }
            // Перехват ошибок
            catch (Exception e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await JsonSerializer.SerializeAsync(context.Response.OutputStream, new ResultError(e.Message));
            }
            finally
            {
                context.Response.Close();
            }
        }
        // ReSharper disable once FunctionNeverReturns
    }
}