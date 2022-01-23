using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Interop.Data
{
    public class FilmDto
    {
        public int Id { get; set; }

        public double Price { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public CountryDto Country { get; set; }
        public int? CountryId { get; set; }
        public GenreDto Genre { get; set; }
        public int? GenreId { get; set; }
        public AgeRatingDto AgeRating { get; set; }
        public int? AgeRatingId { get; set; }
    }
}
