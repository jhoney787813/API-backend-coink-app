using Domain.Entities;

namespace Domain.Interfaces.UseCases
{
	public interface IGetUserByIdUseCase
	{
		Task<User> Execute(string identification);
	}
}