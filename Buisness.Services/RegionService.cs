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
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public RegionService(IRegionRepository repository, ICountryRepository countryRepository, ICityRepository cityRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _regionRepository = repository;
            _mapper = mapper;
        }

        public RegionDto Create(RegionDto region)
        {
            var entity = _mapper.Map<Region>(region);
            _regionRepository.CreateOrUpdate(entity);
            return _mapper.Map<RegionDto>(entity);
        }

        public RegionDto FindById(int id)
        {
            return _mapper.Map<Region, RegionDto>(_regionRepository.Read(id));
        }

        public bool ExistName(string name)
        {
            var regions = _regionRepository.Query()
                .Find(n => n.Name == name);
            return regions != null;
        }

        public IEnumerable<RegionDto> GetRegions()
        {
            var regions = _regionRepository.Query();
            return _mapper.Map<List<Region>, IEnumerable<RegionDto>>(regions);
        }
    }
}
