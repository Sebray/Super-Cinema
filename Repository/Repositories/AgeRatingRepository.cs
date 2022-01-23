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
	public class AgeRatingRepository : AbstractRepository<AgeRating, int>, IAgeRatingRepository
	{
		public AgeRatingRepository(Context context)
		{
			_context = context;
		}
		#region implementation
		protected override int KeySelector(AgeRating entity) => entity.Id;

		protected override AgeRating ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}

		protected override async Task<AgeRating> ReadImplementationAsync(int key)
		{
			return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
		}

		protected override void CreateImplementation(AgeRating value)
		{
			_context.AgeRatings.Add(value);
		}

		protected override async Task CreateImplementationAsync(AgeRating value)
		{
			await _context.AgeRatings.AddAsync(value);
		}

		protected override void UpdateImplementation(AgeRating value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(AgeRating value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.AgeRatings.Remove(entity);
		}

		protected override IQueryable<AgeRating> QueryImplementation()
		{
			return _context.AgeRatings;
		}
		#endregion
	}
}
