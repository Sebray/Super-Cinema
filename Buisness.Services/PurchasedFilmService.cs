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
    public class PurchasedFilmService : IPurchasedFilmService
    {
        private readonly IPurchasedFilmRepository _purchasedFilmRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public PurchasedFilmService(IUserRepository userRepository ,IFilmRepository filmRepository,IPurchasedFilmRepository repository, IMapper mapper)
        {
            _userRepository = userRepository;
            _filmRepository = filmRepository;
            _purchasedFilmRepository = repository;
            _mapper = mapper;
        }

        public PurchasedFilmDto Create(PurchasedFilmDto dto)
        {
            dto.DateOfBuying = new DateTime();
            var entity = _mapper.Map<PurchasedFilm>(dto);
            _purchasedFilmRepository.CreateOrUpdate(entity);
            var film = _filmRepository.Read(dto.FilmId);
            var user = _userRepository.Read(dto.UserId);
            user.Balance -= film.Price;
            _userRepository.CreateOrUpdate(user);
            return _mapper.Map<PurchasedFilmDto>(entity);
        }

        public PurchasedFilmDto FindById(int id)
        {
            return _mapper.Map<PurchasedFilm, PurchasedFilmDto>(_purchasedFilmRepository.Read(id));
        }

        public IEnumerable<PurchasedFilmDto> GetAllFilmsByFilmId(int filmId)
        {
            var films = _purchasedFilmRepository.Query().Where(f => f.FilmId == filmId);
            return _mapper.Map<IEnumerable<PurchasedFilm>, IEnumerable<PurchasedFilmDto>>(films);
        }
        public IEnumerable<PurchasedFilmDto> GetAllFilmsByUserId(int userId)
        {
            var films = _purchasedFilmRepository.Query().Where(f => f.UserId == userId);
            return _mapper.Map<IEnumerable<PurchasedFilm>, IEnumerable<PurchasedFilmDto>>(films);
        }

        public bool Valid(PurchasedFilmDto dto)
        {
            var films = _purchasedFilmRepository.Query().Where(f => f.FilmId == dto.FilmId && f.UserId == dto.UserId);
            if (films != null && films.Count() > 0)
                return false;
            var user = _userRepository.Read(dto.UserId);
            var film = _filmRepository.Read(dto.FilmId);
            if (user.Balance < film.Price)
                return false;
            
            return true;
        }
    }
}
