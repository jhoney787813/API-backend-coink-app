using Domain.Entities;

namespace Domain.Interfaces.UseCases
{
	public interface IGetUserByIdUseCase
	{
		Task<UserData> Execute(string identification);
	}
}