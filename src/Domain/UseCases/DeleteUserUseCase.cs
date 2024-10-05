using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
namespace Domain.UseCases
{
	public class DeleteUserUseCase : IDeleteUserUseCase
    {
        private readonly IUsersRepository _UsersRepository;
        public DeleteUserUseCase(IUsersRepository UsersRepository)
        {
            _UsersRepository = UsersRepository;
        }

        public async Task Execute(string identification)
        {
            await _UsersRepository.Delete(identification);
        }
    }
}