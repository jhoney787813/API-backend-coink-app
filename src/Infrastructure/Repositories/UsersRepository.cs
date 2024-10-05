using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
	public class UsersRepository : IUsersRepository
    {
        private List<User> _Users;

		public UsersRepository()
		{
            _Users = new List<User>();
		}

        public async Task<User> Add(User User)
        {
            _Users.Add(User);
            return User;
        }

        public async Task Delete(string identification)
        {
            _Users.Remove(_Users.FirstOrDefault(x=> x.Identification == identification));
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return _Users;
        }

        public async Task<User> GetById(string identification)
        {
            return _Users.FirstOrDefault(x => x.Identification == identification)!;
        }
    }
}

