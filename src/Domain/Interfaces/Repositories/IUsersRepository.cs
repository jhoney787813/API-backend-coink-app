using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
	public interface IUsersRepository
	{
		Task<IEnumerable<UserData>> GetAll();
        Task<UserData> GetById(string identification);
		Task<User> Add(User User);
		Task Delete(string identification);
    }
}