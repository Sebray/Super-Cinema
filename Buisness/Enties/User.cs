using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Enties
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime Birthday { get; set; }
        public City City { get; set; }
        public int? CityId { get; set; }
    }
}
