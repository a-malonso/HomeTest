using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SaviaHomeTest.Application.Behaviors;
using System.Reflection;

namespace SaviaHomeTest.Application.Extensions;
/// <summary>
/// Adds the application layer services
/// </summary>
public static class ApplicationServicesExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
    }
}
