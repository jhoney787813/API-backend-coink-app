using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
namespace Domain.UseCases
{
	public class GetUserByIdUseCase : IGetUserByIdUseCase
    {
        private readonly IUsersRepository _customersRepository;

        public GetUserByIdUseCase(IUsersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<User> Execute(string identification)
        {
            var result = await _customersRepository.GetById(identification);
            return result;
        }
    }
}

