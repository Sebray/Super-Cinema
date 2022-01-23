using Buisness.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Cinema.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenreController : Controller
	{
		private readonly IGenreService _genreService;

		public GenreController(IGenreService genreService)
		{
			_genreService = genreService;
		}

		[HttpGet("find/{name}")]
		public JsonResult FindByName(string name)
		{
			return Json(_genreService.FindByName(name));
		}
	}
}
