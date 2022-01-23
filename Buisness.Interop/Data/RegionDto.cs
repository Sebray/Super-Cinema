using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Interop.Data
{
    public class RegionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CountryDto> Countries { get; set; }
    }
}
