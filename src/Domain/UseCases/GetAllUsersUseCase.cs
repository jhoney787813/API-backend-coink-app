using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;

namespace Domain.UseCases
{
    public class GetAllUsersUseCase : IGetAllUserUseCase
    {
        private readonly IUsersRepository _customersRepository;

        public GetAllUsersUseCase(IUsersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public Task<IEnumerable<User>> Execute()
        {
            return _customersRepository.GetAll();
        }
    }
}