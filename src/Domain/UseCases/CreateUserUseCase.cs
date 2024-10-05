using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
namespace Domain.UseCases
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUsersRepository _UsersRepository;

        public CreateUserUseCase(IUsersRepository UsersRepository)
        {
            _UsersRepository = UsersRepository;
        }

        public async Task<User> Execute(User User)
        {
            var result = await _UsersRepository.Add(User);
            return result;
        }
    }
}