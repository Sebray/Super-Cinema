using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Enties
{
    public class Country : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<City> Cities { get; set; }
        public Region Region { get; set; }
        public int? RegionId { get; set; }
    }
}
