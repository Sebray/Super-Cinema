using AutoMapper;

using Buisness.Repositories;
using Buisness.Repositories.DataRepositories;
using Buisness.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Repository;
using Repository.Data;
using Repository.Repositories;

namespace Cinema
{
	public class Startup
	{
		private readonly IWebHostEnvironment _environment;

		private readonly IConfigurationRoot _configuration;
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration, IWebHostEnvironment environment)
		{
			Configuration = configuration;
			_environment = environment;
			var builder = new ConfigurationBuilder()
				.SetBasePath(_environment.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{_environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
				.AddEnvironmentVariables();
			_configuration = builder.Build();
		}

		

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			#region common 
			services.AddSingleton<IConfiguration>(_configuration);
/*
			services.AddDbContext<Context>(
				options => options
					.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")),
				contextLifetime: ServiceLifetime.Singleton,
				optionsLifetime: ServiceLifetime.Transient);*/
			services.AddDbContext<Context>(
				options => options
				.UseSqlServer(_configuration.GetConnectionString("SecondConnection")), 
				contextLifetime: ServiceLifetime.Singleton, 
				optionsLifetime: ServiceLifetime.Transient);


			services.AddScoped<IFilmRepository, FilmRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<ICityRepository, CityRepository>();
			services.AddScoped<IPurchasedFilmRepository, PurchasedFilmRepository>();
			services.AddScoped<IRegionRepository, RegionRepository>();
			services.AddScoped<ICountryRepository, CountryRepository>();
			services.AddScoped<IGenreRepository, GenreRepository>();
			services.AddScoped<IAgeRatingRepository, AgeRatingRepository>();



			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new ServiceMappingProfile());
			});

			var mapper = mappingConfig.CreateMapper();
			services.AddSingleton(mapper);

			services.AddControllersWithViews();
			#endregion

			services.AddScoped<IFilmService, FilmService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<ICityService, CityService>();
			services.AddScoped<IPurchasedFilmService, PurchasedFilmService>();
			services.AddScoped<IRegionService, RegionService>();
			services.AddScoped<ICountryService, CountryService>();
			services.AddScoped<IGenreService, GenreService>();
			services.AddScoped<IAgeRatingService, AgeRatingService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
