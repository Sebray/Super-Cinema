using AutoMapper;
using Buisness.Enties;
using Buisness.Interop.Data;
using Buisness.Repositories.DataRepositories;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IPurchasedFilmRepository _purchasedFilmRepository;
		private readonly IMapper _mapper;

		public UserService(IUserRepository repository, IPurchasedFilmRepository purchasedFilmRepository, IMapper mapper)
		{
			_purchasedFilmRepository = purchasedFilmRepository;
			_userRepository = repository;
			_mapper = mapper;
		}

		public UserDto CreateUser(UserDto user)
		{
			var entity = _mapper.Map<User>(user);
			_userRepository.CreateOrUpdate(entity);
			return _mapper.Map<UserDto>(entity);
		}

		public UserDto UpdateUser(UserDto user)
		{
			return CreateUser(user);
		}
		public UserDto FindById(int id)
		{
			return _mapper.Map<User, UserDto>(_userRepository.Read(id));
		}

		public void DeleteById(int id)
		{
			_purchasedFilmRepository.Delete(_purchasedFilmRepository.Query().Where(f => f.UserId == id));
			_userRepository.Delete(_userRepository.Read(id));
		}

		public IEnumerable<UserDto> GetAllUsers()
		{
			return _mapper.Map<List<User>, IEnumerable<UserDto>>(_userRepository.Query());
		}

		public bool ExistByLogin(string login)
		{
			var users = _userRepository.Query()
				.Find(n => n.Login == login);
			return users != null;

		}
		public MemoryStream GetXlsx()
		{
			using var workbook = new XLWorkbook();
			var worksheet = workbook.Worksheets.Add();

			worksheet.Cell(1, 1).Value = "Логин пользователя";
			worksheet.Cell(1, 2).Value = "Сумма покупок";
			int i = 2;
			foreach (var user in _userRepository.Query())
			{
				worksheet.Cell(i, 1).Value = user.Login;
				worksheet.Cell(i, 2).Value = _purchasedFilmRepository.Query().Where(f => f.UserId == user.Id).Sum(f => f.Film.Price);
				i++;
			}

			worksheet.Columns().AdjustToContents();

			using var stream = new MemoryStream();
			workbook.SaveAs(stream);

			return stream;
		}
	}
}
