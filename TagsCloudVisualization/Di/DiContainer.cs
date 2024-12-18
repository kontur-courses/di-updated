using Autofac;

namespace TagsCloudVisualization.Di;

public class DiContainer
{
    public static IContainer Configure()
    {
        var builder = new ContainerBuilder();
        
        // Здесь будут зарегистрированы все зависимости
        
        return builder.Build();
    }
}