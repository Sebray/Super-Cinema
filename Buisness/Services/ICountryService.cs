using Buisness.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public interface ICountryService
    {
        public IEnumerable<CountryDto> GetCountries();
        public CountryDto Create(CountryDto countryDto);
        public IEnumerable<CountryDto> FindByName(string name);
        public bool ExistName(string name);
        public CountryDto FindById(int id);
    }
}
