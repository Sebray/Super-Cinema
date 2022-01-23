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
	public class AgeRatingController : Controller
	{
		private readonly IAgeRatingService _ageRatingService;

		public AgeRatingController(IAgeRatingService ageRatingService)
		{
			_ageRatingService = ageRatingService;
		}

		[HttpGet("find/{rating}")]
		public JsonResult FindByName(string rating)
		{
			return Json(_ageRatingService.FindByRating(rating));
		}
	}
}
