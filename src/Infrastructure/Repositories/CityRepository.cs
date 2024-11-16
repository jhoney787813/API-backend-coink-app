using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Mapper;
using Infrastructure.Model;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromHours(1); 
        private const string CacheKey = "AllCities"; 

        public CityRepository(IDbConnection dbConnection, IMemoryCache cache)
        {
            _dbConnection = dbConnection;
            _cache = cache;

        }

        private async Task LoadCitiesToCacheAsync()
        {
           

            try
            {
                var sql = @"SELECT * FROM  fnGetAllCities();";
                var cities = await _dbConnection.QueryAsync<CityModel>(sql);

                _cache.Set(CacheKey, cities, _cacheDuration);
            }
            catch (Exception ex)
            {
                throw;
            }

          
        }


        public async Task<bool> CityExistsAsync(string name)
        {  
            if (!_cache.TryGetValue(CacheKey, out List<CityModel> cities))
            {         
                await LoadCitiesToCacheAsync();
                cities = _cache.Get<List<CityModel>>(CacheKey);
            }
            return cities.Any(city => city.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<List<City>> GetAllCitiesAsync()
        {
            List<City> citieslist = new List<City>();
            if (!_cache.TryGetValue(CacheKey, out List<CityModel> cities))
            {
                await LoadCitiesToCacheAsync();
                cities = _cache.Get<List<CityModel>>(CacheKey);
                cities.ForEach(c =>
                {
                    citieslist.Add(CityMapper.ToEntity(c));
                });
            }
            return await Task.FromResult(citieslist).ConfigureAwait(true);
        }

    }
}
