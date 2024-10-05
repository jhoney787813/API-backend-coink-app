using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
	public interface IUsersRepository
	{
		Task<IEnumerable<User>> GetAll();
        Task<User> GetById(string identification);
		Task<User> Add(User User);
		Task Delete(string identification);
    }
}