using AutoMapper;

using Buisness.Enties;
using Buisness.Interop.Data;
using Buisness.Repositories;
using Buisness.Repositories.DataRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Buisness.Services
{
    public class AgeRatingService : IAgeRatingService
    {
        private readonly IAgeRatingRepository _ageRatingRepository;
        private readonly IMapper _mapper;
        private readonly IPurchasedFilmRepository _purchasedFilmRepository;
        private readonly IFilmRepository _filmRepository;

        public AgeRatingService(IFilmRepository filmRepository, IPurchasedFilmRepository purchasedFilmRepository,IAgeRatingRepository repository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _purchasedFilmRepository = purchasedFilmRepository;
            _ageRatingRepository = repository;
            _mapper = mapper;
        }

        public AgeRatingDto FindById(int id)
        {
            return _mapper.Map<AgeRating, AgeRatingDto>(_ageRatingRepository.Read(id));
        }

        public IEnumerable<AgeRatingDto> FindByRating(string rating)
        {
            var ageRatings = _ageRatingRepository.Query()
                .Where(i => i.Rating == rating);

            return _mapper.Map<IEnumerable<AgeRating>, IEnumerable<AgeRatingDto>>(ageRatings);
        }

        public IEnumerable<AgeRatingDto> GetAgeRatings()
        {
            var ageRatings = _ageRatingRepository.Query();

            return _mapper.Map<List<AgeRating>, IEnumerable<AgeRatingDto>>(ageRatings);
        }


        public AgeRatingDto CreateAgeRating(AgeRatingDto dto)
        {
           var entity = _mapper.Map<AgeRating>(dto);
            _ageRatingRepository.CreateOrUpdate(entity);
            return _mapper.Map<AgeRatingDto>(entity);
        }

        public void DeleteById(int id)//Сначала нужно удалить фильмы с таким жанром
        {
            var films = _filmRepository.Query().Where(f => f.AgeRatingId == id);
            foreach (var film in films)
            {
                var purchased = _purchasedFilmRepository.Query().Where(p => p.FilmId == film.Id);
                _purchasedFilmRepository.Delete(purchased);
            }
            _filmRepository.Delete(films);
            _ageRatingRepository.Delete(_ageRatingRepository.Read(id));
        }

        public bool ValidRating(string rating)
        {
            try
            {
                int.Parse(rating.Substring(0, rating.Length - 2));
                if (rating.Last() != '+')
                    return false;

                var ageRatings = _ageRatingRepository.Query()
                .Find(n => n.Rating == rating);
                return ageRatings != null;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


    }
}
