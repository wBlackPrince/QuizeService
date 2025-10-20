using QuizeService.Application;

namespace QuizeService.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebDependencies(this IServiceCollection services)
    {
        services.AddApplication();

        return services;
    }
}