using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Enties
{
    public class Region : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Country> Countries { get; set; }
    }
}
