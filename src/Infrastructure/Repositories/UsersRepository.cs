using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Data;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace Infrastructure.Repositories
{
	public class UsersRepository : IUsersRepository
    {
        private readonly IDbConnection _dbConnection;

		public UsersRepository(IDbConnection dbConnection)
		{
            _dbConnection = dbConnection;

		}

        public async Task<User> Add(User User)
        {
            try
            {
                var sql = @"CALL spInsertUserData(@CardId, @Name, @Phone, @Address, @CityId)";
                await _dbConnection.ExecuteAsync(sql, new { CardId = User.Identification, Name= User.FullName, Phone=User.Phone, Address= User.Address, CityId= User.CityId });

                return User;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task Delete(string identification)
        {
            try
            {
                var sql = "CALL spDeleteUserByCardId(@CardId);";
                await _dbConnection.ExecuteAsync(sql, new { CardId = identification });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<UserData>> GetAll()
        {
            try
            {
                var sql = @"SELECT * FROM fnGetUsersData();";
                return await _dbConnection.QueryAsync<UserData>(sql);
            }catch (Exception ex)
            {
                return null;
            }
        
        }

        public async Task<UserData> GetById(string identification)
        {
            try
            {
                var sql = @"SELECT * FROM fnGetUserByCardId(@CardId);";
                return await _dbConnection.QueryFirstOrDefaultAsync<UserData>(sql, new { CardId = identification });
            }
            catch(Exception ex)
            {
                return null;
            }

        }
    }
}

