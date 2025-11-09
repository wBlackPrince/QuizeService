using Microsoft.Extensions.DependencyInjection;
using QuizeService.Application.UseCases;

namespace QuizeService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<GetTestByIdUseCase>();
        services.AddScoped<CreateTestUseCase>();
        services.AddScoped<AddMatchQuestionUseCase>();
        services.AddScoped<AddSingleChoiceQuestionUseCase>();
        services.AddScoped<AddTextInputQuestionUseCase>();

        return services;
    }
}