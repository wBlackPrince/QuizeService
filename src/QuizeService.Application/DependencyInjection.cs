using Microsoft.Extensions.DependencyInjection;
using QuizeService.Application.UseCases;

namespace QuizeService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateTestUseCase>();

        return services;
    }
}