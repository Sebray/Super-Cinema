using AutoMapper;
using Buisness.Enties;
using Buisness.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
	public class ServiceMappingProfile : Profile
	{
		public ServiceMappingProfile()
		{
			// from entity to dto
			CreateMap<AgeRating, AgeRatingDto>();
			CreateMap<City, CityDto>();
			CreateMap<Country, CountryDto>();
			CreateMap<Film, FilmDto>();
			CreateMap<Genre, GenreDto>();
			CreateMap<PurchasedFilm, PurchasedFilmDto>();
			CreateMap<Region, RegionDto>();
			CreateMap<User, UserDto>();


			// from dto to entity
			CreateMap<AgeRatingDto, AgeRating>();
			CreateMap<CityDto, City>();
			CreateMap<CountryDto, Country>();
			CreateMap<FilmDto, Film>();
			CreateMap<GenreDto, Genre>();
			CreateMap<PurchasedFilmDto, PurchasedFilm>();
			CreateMap<RegionDto, Region>();
			CreateMap<UserDto, User>();
		}
	}
}
