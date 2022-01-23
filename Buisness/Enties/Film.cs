using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Enties
{
    public class Film : IBaseEntity
    {
        public int Id { get; set; }

        public double Price { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public  Country Country { get; set; }
        public Genre Genre { get; set; }
        public int? GenreId { get; set; }
        public int? CountryId { get; set; }
        public AgeRating AgeRating { get; set; }
        public int? AgeRatingId { get; set; }
    }
}
