using Domain.Interfaces.UseCases;
using Domain.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class DomainDI
{
    public static IServiceCollection AddDomainLayer(this IServiceCollection services)
    {
        services.AddTransient<ICreateUserUseCase, CreateUserUseCase>();
        services.AddTransient<IDeleteUserUseCase, DeleteUserUseCase>();
        services.AddTransient<IGetAllUserUseCase, GetAllUsersUseCase>();
        services.AddTransient<IGetUserByIdUseCase, GetUserByIdUseCase>();
        return services;
    }
}