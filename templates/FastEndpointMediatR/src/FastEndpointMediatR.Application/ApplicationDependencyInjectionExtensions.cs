using Microsoft.Extensions.DependencyInjection;

namespace FastEndpointMediatR.Application;

public static class ApplicationDependencyInjectionExtensions
{
    public static IServiceCollection AddApplicationMediatR(this IServiceCollection service)
    {
        return service.AddMediatR(typeof(ApplicationDependencyInjectionExtensions));
    }
}
