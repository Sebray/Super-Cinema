using Buisness.Enties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
	public class Context : DbContext
	{
		public DbSet<AgeRating> AgeRatings { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Film> Films { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<PurchasedFilm> PurchasedFilms { get; set; }
		public DbSet<Region> Regions { get; set; }
		public DbSet<User> Users { get; set; }

		public Context(DbContextOptions<Context> options) : base(options) {
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
