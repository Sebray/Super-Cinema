using Buisness.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public interface IPurchasedFilmService
    {
        public PurchasedFilmDto Create(PurchasedFilmDto dto);
        public bool Valid(PurchasedFilmDto dto);
        public IEnumerable<PurchasedFilmDto> GetAllFilmsByFilmId(int id);
        public IEnumerable<PurchasedFilmDto> GetAllFilmsByUserId(int id);
        public PurchasedFilmDto FindById(int id);
    }
}
