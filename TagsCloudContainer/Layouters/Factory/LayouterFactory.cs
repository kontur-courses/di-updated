﻿using System.Drawing;

namespace TagsCloudContainer.Layouters.Factory;

public class LayouterFactory(AppConfig appConfig) : ILayouterFactory
{
    public ILayouter CreateLayouter(Point center = new())
    {
        return appConfig.LayoutType switch
        {
            LayoutType.Circular => new CircularCloudLayouter(appConfig, center),
            LayoutType.Rhombus => new RhombusLayouter(center),
            _ => throw new ArgumentException($"Unknown layout type: {appConfig.LayoutType}")
        };
    }
}