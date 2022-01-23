using Buisness.Enties;
using Buisness.Repositories;
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
    public class FilmRepository : AbstractRepository<Film, int>, IFilmRepository
    {
		public FilmRepository(Context context)
		{
			_context = context;
		}
		#region implementation
		protected override int KeySelector(Film entity) => entity.Id;

		protected override Film ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}

		protected override async Task<Film> ReadImplementationAsync(int key)
		{
			return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
		}

		protected override void CreateImplementation(Film value)
		{
			_context.Films.Add(value);
		}

		protected override async Task CreateImplementationAsync(Film value)
		{
			await _context.Films.AddAsync(value);
		}

		protected override void UpdateImplementation(Film value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(Film value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.Films.Remove(entity);
		}

		protected override IQueryable<Film> QueryImplementation()
		{
			return _context.Films.Include(f=> f.Country).Include(f=> f.AgeRating).Include(f=>f.Genre);
		}
		#endregion
	}
}
