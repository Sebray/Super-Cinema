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
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
          
            _mapper = mapper;
        }

        public CityDto Create(CityDto city)
        {
            var entity = _mapper.Map<City>(city);
            _cityRepository.CreateOrUpdate(entity);
            return _mapper.Map<CityDto>(entity);
        }

        public CityDto FindById(int id)
        {
            return _mapper.Map<City, CityDto>(_cityRepository.Read(id));
        }

        public bool ExistName(string name)
        {
            var cities = _cityRepository.Query()
                .Find(n => n.Name == name);
            return cities != null;
        }

        public IEnumerable<CityDto> GetCities()
        {
            var cities = _cityRepository.Query();
            return _mapper.Map<List<City>, IEnumerable<CityDto>>(cities);
        }

        public IEnumerable<CityDto> FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

