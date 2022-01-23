using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Interop.Data
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public double Balance { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime Birthday { get; set; }
        public CityDto City { get; set; }
        public int CityId { get; set; }
    }
}
