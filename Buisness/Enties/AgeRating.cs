using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Enties
{
    public class AgeRating:IBaseEntity
    {
        public int Id { get; set; }

        public string Rating { get; set; }//0+, 6+ и т.д.
    }
}
