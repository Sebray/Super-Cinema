using Buisness.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public interface ICityService
    {
        public IEnumerable<CityDto> GetCities();
        public CityDto Create(CityDto cityDto);
        public bool ExistName(string name);
        public IEnumerable<CityDto> FindByName(string name);
        public CityDto FindById(int id);
    }
}
