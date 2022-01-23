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
	public class CityController : Controller
	{
		private readonly ICityService _cityService;

		public CityController(ICityService cityService)
		{
			_cityService = cityService;
		}

		[HttpGet("find/{name}")]
		public JsonResult FindByName(string name)
		{
			return Json(_cityService.FindByName(name));
		}
	}
}
