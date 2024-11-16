using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
namespace Domain.UseCases
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ICityRepository _cityRepository;

        public CreateUserUseCase(IUsersRepository UsersRepository,ICityRepository cityRepository)
        {
            _usersRepository = UsersRepository;
            _cityRepository = cityRepository;
        }

        public async Task<User> Execute(User User)
        {
            var result = await _usersRepository.Add(User);
            return result;
        }

        public async Task<bool> IsValidCountry(string name)
        {

            return await _cityRepository.CityExistsAsync(name);


        }

        public async Task<bool> ValidateCountry(string name)
        {
            return await _cityRepository.CityExistsAsync(name);
        }
       
    }
}