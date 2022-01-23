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
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository repository, IFilmRepository filmRepository ,ICityRepository cityRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _cityRepository = cityRepository;
            _countryRepository = repository;
            _mapper = mapper;
        }

        public CountryDto Create(CountryDto country)
        {
            var entity = _mapper.Map<Country>(country);
            _countryRepository.CreateOrUpdate(entity);
            return _mapper.Map<CountryDto>(entity);
        }

        public CountryDto FindById(int id)
        {
            return _mapper.Map<Country, CountryDto>(_countryRepository.Read(id));
        }

        public bool ExistName(string name)
        {
            var countries = _countryRepository.Query()
                .Find(n => n.Name == name);
            return countries != null;
        }

        public IEnumerable<CountryDto> GetCountries()
        {
            var countries = _countryRepository.Query();
            return _mapper.Map<List<Country>, IEnumerable<CountryDto>>(countries);
        }

        public IEnumerable<CountryDto> FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
