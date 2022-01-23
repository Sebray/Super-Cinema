using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Enties
{
    public class PurchasedFilm : IBaseEntity
    {
        public int Id { get; set; }

        public User User { get; set; }
        public int? UserId { get; set; }
        public Film Film { get; set; }
        public int? FilmId { get; set; }

        public DateTime DateOfBuying { get; set; }
    }
}
