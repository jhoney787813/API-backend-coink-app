using Domain.Entities;

namespace Domain.Interfaces.UseCases
{
	public interface IGetAllUserUseCase
	{
		Task<IEnumerable<User>> Execute();
	}
}