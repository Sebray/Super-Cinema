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
    public class PurchasedFilmRepository : AbstractRepository<PurchasedFilm, int>, IPurchasedFilmRepository
    {
		public PurchasedFilmRepository(Context context)
		{
			_context = context;
		}
		#region implementation
		protected override int KeySelector(PurchasedFilm entity) => entity.Id;

		protected override PurchasedFilm ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}

		protected override async Task<PurchasedFilm> ReadImplementationAsync(int key)
		{
			return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
		}

		protected override void CreateImplementation(PurchasedFilm value)
		{
			_context.PurchasedFilms.Add(value);
		}

		protected override async Task CreateImplementationAsync(PurchasedFilm value)
		{
			await _context.PurchasedFilms.AddAsync(value);
		}

		protected override void UpdateImplementation(PurchasedFilm value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(PurchasedFilm value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.PurchasedFilms.Remove(entity);
		}

		protected override IQueryable<PurchasedFilm> QueryImplementation()
		{
			return _context.PurchasedFilms.Include(f => f.Film);
		}
		#endregion
	}
}
