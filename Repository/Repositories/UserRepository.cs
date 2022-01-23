using Buisness.Enties;
using Buisness.Repositories.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
	public class UserRepository : AbstractRepository<User, int>, IUserRepository
	{
		public UserRepository(Context context)
		{
			_context = context;
		}
		#region implementation
		protected override int KeySelector(User entity) => entity.Id;

		protected override User ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}

		protected override async Task<User> ReadImplementationAsync(int key)
		{
			return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
		}

		protected override void CreateImplementation(User value)
		{
			_context.Users.Add(value);
		}

		protected override async Task CreateImplementationAsync(User value)
		{
			await _context.Users.AddAsync(value);
		}

		protected override void UpdateImplementation(User value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(User value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.Users.Remove(entity);
		}

		protected override IQueryable<User> QueryImplementation()
		{
			return _context.Users.Include(u => u.City).ThenInclude(c =>c.Country).ThenInclude(c => c.Region);
		}
		#endregion

		
	}
}
