using Buisness.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public interface IAgeRatingService
    {
        public IEnumerable<AgeRatingDto> GetAgeRatings();
        public IEnumerable<AgeRatingDto> FindByRating(string rating);

        public AgeRatingDto FindById(int id);

        public AgeRatingDto CreateAgeRating(AgeRatingDto dto);
        public void DeleteById(int id);
        public bool ValidRating(string rating);

    }
}
