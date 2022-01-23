using AutoMapper;
using Buisness.Enties;
using Buisness.Interop.Data;
using Buisness.Repositories.DataRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IPurchasedFilmRepository _purchasedFilmRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository repository, IFilmRepository filmRepository ,IPurchasedFilmRepository purchasedFilmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _purchasedFilmRepository = purchasedFilmRepository;
            _genreRepository = repository;
            _mapper = mapper;
        }

        public GenreDto CreateGenre(GenreDto dto)
        {
            var entity = _mapper.Map<Genre>(dto);
            _genreRepository.CreateOrUpdate(entity);
            return _mapper.Map<GenreDto>(entity);
        }

        public void DeleteById(int id)//Сначала нужно удалить фильмы с таким жанром
        {
            var films = _filmRepository.Query().Where(f => f.GenreId == id);
            foreach(var film in films)
            {
                var purchased = _purchasedFilmRepository.Query().Where(p => p.FilmId == film.Id);
                _purchasedFilmRepository.Delete(purchased);
            }
            _filmRepository.Delete(films);
            _genreRepository.Delete(_genreRepository.Read(id));
        }

        public bool ExistName(string name)
        {
            var genres = _genreRepository.Query()
                .Find(n => n.Name == name);
            return genres != null;
        }

        public GenreDto FindById(int id)
        {
            return _mapper.Map<Genre, GenreDto>(_genreRepository.Read(id));
        }

        public IEnumerable<GenreDto> FindByName(string name)
        {
            var genres = _genreRepository.Query()
                .Where(i => i.Name.Contains(name, System.StringComparison.InvariantCultureIgnoreCase));

            return _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDto>>(genres);
        }

        public IEnumerable<GenreDto> GetGenres()
        {
            var genres = _genreRepository.Query();

            return _mapper.Map<List<Genre>, IEnumerable<GenreDto>>(genres);
        }

        public GenreDto UpdateGenre(GenreDto dto)
        {
            return CreateGenre(dto);
        }
    }
}
