
using Microsoft.Extensions.Configuration;
using Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // Add DbContext
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("PostgresDb"));
        });
        // Add Redis
   
        // Add AutoMapper
    }
}