using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaviaHomeTest.Application.Abstractions;
using SaviaHomeTest.Infrastructure.Persistence;
using SaviaHomeTest.Infrastructure.Persistence.Repositories;
using System.Reflection;

namespace SaviaHomeTest.Infrastructure.Extensions;

public static class InfrastructureServicesExtensions
{
    /// <summary>
    /// Adds the infrastructure layer services
    /// </summary>
    /// <param name="services"></param>
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        // Write database
        services.AddDbContext<AppDbContextWrite>(options =>
        {
            options.UseInMemoryDatabase(databaseName: "TasksToDoWrite");
        });

        // Read database
        services.AddDbContext<AppDbContextRead>(options =>
        {
            options.UseInMemoryDatabase(databaseName: "TasksToDoRead");
        });

        services.AddScoped(typeof(IAppRepository<>), typeof(AppRepository<>));
    }
}
