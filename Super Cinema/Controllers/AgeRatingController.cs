using Buisness.Interop.Data;
using Buisness.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Cinema.Controllers
{
    public class AgeRatingController : Controller
    {
        private readonly IAgeRatingService _ageRatingService;

        public AgeRatingController(IAgeRatingService ageRatingService)
        {
            _ageRatingService = ageRatingService;
        }

        // GET: AgeRatingController
        public ActionResult Index()
        {
            var ageRatings = _ageRatingService.GetAgeRatings();
            return View(ageRatings);
        }

        // GET: AgeRatingController/Create
        public ActionResult Create()
        {
            return View("CreateOrUpdate");
        }

        // Get: AgeRatingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View("CreateOrUpdate", _ageRatingService.FindById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(AgeRatingDto dto)
        {
            if (!ModelState.IsValid || (dto.Id == 0 && _ageRatingService.ValidRating(dto.Rating)))
            {
                return View(dto);
            }
            _ageRatingService.CreateAgeRating(dto);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _ageRatingService.DeleteById(id);

            return RedirectToAction("Index");
        }
    }
}