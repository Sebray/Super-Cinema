using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Enties
{
    public class City : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Country Country { get; set; }
        public int? CountryId { get; set; }
    }
}
