using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
	public class UsersRepository : IUsersRepository
    {
        private List<User> _customers;

		public UsersRepository()
		{
            _customers = new List<User>();
		}

        public async Task<User> Add(User customer)
        {
            _customers.Add(customer);
            return customer;
        }

        public async Task Delete(string identification)
        {
            _customers.Remove(_customers.FirstOrDefault(x=> x.Identification == identification));
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return _customers;
        }

        public async Task<User> GetById(string identification)
        {
            return _customers.FirstOrDefault(x => x.Identification == identification)!;
        }
    }
}

