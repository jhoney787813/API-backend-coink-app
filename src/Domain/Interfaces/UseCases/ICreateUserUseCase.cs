using Domain.Entities;

namespace Domain.Interfaces.UseCases
{
	public interface ICreateUserUseCase
	{
		Task<User> Execute(User user);
        Task<bool> ValidateCountry(string name);
    }
}