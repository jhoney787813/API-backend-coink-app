using Domain.Entities;
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper
{
    public static class CityMapper
    {
        public static CityModel ToModel(City city) => new CityModel(city.Id,
                                                                 city.Name,
                                                                 city.Prefix,
                                                                 city.StateId,
                                                                 city.CreatedAt);

        public static City ToEntity(CityModel cityDto) => new City
        {
            Id = cityDto.Id,
            Name = cityDto.Name,
            Prefix = cityDto.Prefix,
            StateId = cityDto.StateId,
            CreatedAt = cityDto.CreatedAt
        };
    }
}
