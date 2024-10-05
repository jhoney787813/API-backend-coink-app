using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
namespace Domain.UseCases
{
	public class DeleteUserUseCase : IDeleteUserUseCase
    {
        private readonly IUsersRepository _customersRepository;
        public DeleteUserUseCase(IUsersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task Execute(string identification)
        {
            await _customersRepository.Delete(identification);
        }
    }
}