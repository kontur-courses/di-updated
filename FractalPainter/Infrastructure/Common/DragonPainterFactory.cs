using FractalPainting.Application.Fractals;

namespace FractalPainting.Infrastructure.Common;

public class DragonPainterFactory(IImageSettingsProvider imageSettingsProvider, Palette palette) : IDragonPainterFactory
{
    public DragonPainter Create(DragonSettings settings)
        => new(settings, imageSettingsProvider, palette);
}