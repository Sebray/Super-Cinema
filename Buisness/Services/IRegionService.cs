using Buisness.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public interface IRegionService
    {
        public IEnumerable<RegionDto> GetRegions();
        public RegionDto Create(RegionDto region);
        public RegionDto FindById(int id);
        public bool ExistName(string name);
    }
}
