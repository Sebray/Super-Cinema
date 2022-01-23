using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Interop.Data
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CityDto> Cities { get; set; }
        public RegionDto Region { get; set; }
        public int RegionId { get; set; }


    }
}
