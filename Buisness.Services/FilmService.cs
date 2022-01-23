using AutoMapper;

using Buisness.Enties;
using Buisness.Interop.Data;
using Buisness.Repositories;
using Buisness.Repositories.DataRepositories;
using System.Collections.Generic;
using System.Linq;
namespace Buisness.Services
{
    public class FilmService:IFilmService
    {
		private readonly IFilmRepository _filmRepository;
		private readonly IPurchasedFilmRepository _purchasedFilmRepository;
		private readonly IMapper _mapper;

		public FilmService(IFilmRepository repository, IPurchasedFilmRepository purchasedFilmRepository, IMapper mapper)
		{
			_purchasedFilmRepository = purchasedFilmRepository;
			_filmRepository = repository;
			_mapper = mapper;
		}

		public FilmDto CreateFilm(FilmDto film)
		{
			var entity = _mapper.Map<Film>(film);
			_filmRepository.CreateOrUpdate(entity);
			return _mapper.Map<FilmDto>(entity);
		}

		public FilmDto UpdateFilm(FilmDto film)
		{
			return CreateFilm(film);
		}
		public FilmDto FindById(int id)
		{
			return _mapper.Map<Film, FilmDto>(_filmRepository.Read(id));
		}

		public void DeleteById(int id)
		{
			_purchasedFilmRepository.Delete(_purchasedFilmRepository.Query().Where(f => f.FilmId == id));
			_filmRepository.Delete(_filmRepository.Read(id));
		}

		public IEnumerable<FilmDto> GetFilms()
		{
			return _mapper.Map<List<Film>, IEnumerable<FilmDto>>(_filmRepository.Query());
		}
	}
}
