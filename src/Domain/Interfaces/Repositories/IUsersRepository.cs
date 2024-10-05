using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
	public interface IUsersRepository
	{
		Task<IEnumerable<User>> GetAll();
        Task<User> GetById(string identification);
		Task<User> Add(User customer);
		Task Delete(string identification);
    }
}