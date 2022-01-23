using Buisness.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public interface IGenreService
    {
        public void DeleteById(int id);
        public GenreDto FindById(int id);
        public GenreDto CreateGenre(GenreDto dto);
        public GenreDto UpdateGenre(GenreDto dto);
        public IEnumerable<GenreDto> GetGenres();
        public bool ExistName(string name);
        public IEnumerable<GenreDto> FindByName(string name);
    }
}
