using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;

namespace Domain.UseCases
{
    public class GetAllUsersUseCase : IGetAllUserUseCase
    {
        private readonly IUsersRepository _UsersRepository;

        public GetAllUsersUseCase(IUsersRepository UsersRepository)
        {
            _UsersRepository = UsersRepository;
        }

        public Task<IEnumerable<UserData>> Execute()
        {
            return _UsersRepository.GetAll();
        }
    }
}