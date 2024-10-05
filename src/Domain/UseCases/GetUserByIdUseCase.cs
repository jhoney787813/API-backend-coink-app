using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
namespace Domain.UseCases
{
	public class GetUserByIdUseCase : IGetUserByIdUseCase
    {
        private readonly IUsersRepository _UsersRepository;

        public GetUserByIdUseCase(IUsersRepository UsersRepository)
        {
            _UsersRepository = UsersRepository;
        }

        public async Task<UserData> Execute(string identification)
        {
            var result = await _UsersRepository.GetById(identification);
            return result;
        }
    }
}

