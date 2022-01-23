using Buisness.Interop.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public interface IUserService
    {
        public UserDto CreateUser(UserDto user);
        public void DeleteById(int id);
        public UserDto UpdateUser(UserDto user);
        public IEnumerable<UserDto> GetAllUsers();
        public UserDto FindById(int id);
        public bool ExistByLogin(string login);
        public MemoryStream GetXlsx();
    }
}
