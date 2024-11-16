using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface ICityRepository
    {
        Task<bool> CityExistsAsync(string name);
        Task<List<City>> GetAllCitiesAsync();
    }
}
