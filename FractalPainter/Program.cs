using FractalPainting.Application;
using FractalPainting.Application.Actions;
using FractalPainting.Application.Fractals;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<IObjectSerializer, XmlObjectSerializer>();
services.AddSingleton<IBlobStorage, FileBlobStorage>();
services.AddSingleton<SettingsManager>();

services.AddSingleton(new Palette());
services.AddSingleton<IImageSettingsProvider>(sp => sp.GetRequiredService<SettingsManager>().Load());

services.AddSingleton<KochPainter>();
services.AddSingleton<IDragonPainterFactory, DragonPainterFactory>();

services.AddSingleton<IApiAction, KochFractalAction>();
services.AddSingleton<IApiAction, DragonFractalAction>();
services.AddSingleton<IApiAction, UpdateImageSettingsAction>();
services.AddSingleton<IApiAction, GetImageSettingsAction>();
services.AddSingleton<IApiAction, UpdatePaletteSettingsAction>();
services.AddSingleton<IApiAction, GetPaletteSettingsAction>();

services.AddSingleton<App>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<App>();

await app.Run();