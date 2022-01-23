using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Interop.Data
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountryDto Country { get; set; }
        public int CountryId { get; set; }
    }
}
