using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
namespace Domain.UseCases
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUsersRepository _customersRepository;

        public CreateUserUseCase(IUsersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<User> Execute(User customer)
        {
            var result = await _customersRepository.Add(customer);
            return result;
        }
    }
}