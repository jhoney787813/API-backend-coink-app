using Domain.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;
namespace Infrastructure;

public static class InfrastructureDI
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDbConnection>(sp =>
           new NpgsqlConnection(configuration.GetConnectionString("SupabaseConnection")));
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddMemoryCache();
        return services;
    }
}