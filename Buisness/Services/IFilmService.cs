using Buisness.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public interface IFilmService
    {
        public FilmDto CreateFilm(FilmDto film);
        public FilmDto UpdateFilm(FilmDto film);
        public IEnumerable<FilmDto> GetFilms();
        public FilmDto FindById(int id);
        public void DeleteById(int id);
    }
}
