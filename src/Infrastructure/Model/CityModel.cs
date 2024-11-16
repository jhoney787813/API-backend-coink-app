using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public int StateId { get; set; }
        public DateTime CreatedAt { get; set; }

        public CityModel(int id, string name, string prefix, int stateId, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Prefix = prefix;
            StateId = stateId;
            CreatedAt = createdAt;
        }

        public CityModel() { }
    }
}
