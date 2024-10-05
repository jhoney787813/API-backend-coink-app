using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public record UserDataModel(string CardId, string Name, string Phone, string Address, int CityId,  string CityName );
}
