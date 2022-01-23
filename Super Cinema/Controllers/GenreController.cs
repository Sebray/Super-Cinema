using Buisness.Interop.Data;
using Buisness.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Cinema.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: GenreController
        public ActionResult Index()
        {
            var genres = _genreService.GetGenres();
            return View(genres);
        }

        // GET: GenreController/Create
        public ActionResult Create()
        {
            return View("CreateOrUpdate");
        }

        // Get: GenreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View("CreateOrUpdate", _genreService.FindById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(GenreDto dto)
        {
            if (!ModelState.IsValid || (dto.Id == 0 && _genreService.ExistName(dto.Name)))
            {
                return View(dto);
            }
            _genreService.CreateGenre(dto);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _genreService.DeleteById(id);

            return RedirectToAction("Index");
        }
    }
}
