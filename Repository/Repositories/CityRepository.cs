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
	public class CityRepository : AbstractRepository<City, int>, ICityRepository
	{
		public CityRepository(Context context)
		{
			_context = context;
		}

		#region implementation
		protected override int KeySelector(City entity) => entity.Id;

		protected override City ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}

		protected override async Task<City> ReadImplementationAsync(int key)
		{
			return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
		}

		protected override void CreateImplementation(City value)
		{
			_context.Cities.Add(value);
		}

		protected override async Task CreateImplementationAsync(City value)
		{
			await _context.Cities.AddAsync(value);
		}

		protected override void UpdateImplementation(City value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(City value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.Cities.Remove(entity);
		}

		protected override IQueryable<City> QueryImplementation()
		{
			return _context.Cities;
		}
		#endregion
	}
}
