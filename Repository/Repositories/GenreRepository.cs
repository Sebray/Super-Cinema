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
	public class GenreRepository : AbstractRepository<Genre, int>, IGenreRepository
	{
		public GenreRepository(Context context)
		{
			_context = context;
		}
		#region implementation
		protected override int KeySelector(Genre entity) => entity.Id;

		protected override Genre ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}

		protected override async Task<Genre> ReadImplementationAsync(int key)
		{
			return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
		}

		protected override void CreateImplementation(Genre value)
		{
			_context.Genres.Add(value);
		}

		protected override async Task CreateImplementationAsync(Genre value)
		{
			await _context.Genres.AddAsync(value);
		}

		protected override void UpdateImplementation(Genre value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(Genre value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.Genres.Remove(entity);
		}

		protected override IQueryable<Genre> QueryImplementation()
		{
			return _context.Genres;
		}
		#endregion
	}
}
