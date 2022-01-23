using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Interop.Data
{
    public class PurchasedFilmDto
    {
        public int Id { get; set; }

        public UserDto User { get; set; }
        public int UserId { get; set; }
        public FilmDto Film { get; set; }
        public int FilmId { get; set; }

        public DateTime DateOfBuying { get; set; }
    }
}
