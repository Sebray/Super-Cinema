using Buisness.Interop.Data;
using Buisness.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Cinema.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;
        private readonly ICountryService _countryService;
        private readonly IGenreService _genreService;
        private readonly IAgeRatingService _ageRatingService;

        public FilmController(IFilmService filmService, ICountryService countryService, IGenreService genreService, IAgeRatingService ageRatingService)
        {
            _filmService = filmService;
            _countryService = countryService;
            _genreService = genreService;
            _ageRatingService = ageRatingService;
        }
        // GET: FilmController
        public ActionResult Index()
        {
            var films = _filmService.GetFilms();
            return View(films);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            return View(_filmService.FindById(id));
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {
            ViewData["CountryIds"] = new SelectList(_countryService.GetCountries(),
                    dataValueField: nameof(CountryDto.Id),
                    dataTextField: nameof(CountryDto.Name));
            ViewData["GenreIds"] = new SelectList(_genreService.GetGenres(),
                dataValueField: nameof(GenreDto.Id),
                dataTextField: nameof(GenreDto.Name));
            ViewData["AgeRatingIds"] = new SelectList(_ageRatingService.GetAgeRatings(),
                dataValueField: nameof(AgeRatingDto.Id),
                dataTextField: nameof(AgeRatingDto.Rating));
            return View("CreateOrUpdate");
        }
        
        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["CountryIds"] = new SelectList(_countryService.GetCountries(),
                    dataValueField: nameof(CountryDto.Id),
                    dataTextField: nameof(CountryDto.Name));
            ViewData["GenreIds"] = new SelectList(_genreService.GetGenres(),
                dataValueField: nameof(GenreDto.Id),
                dataTextField: nameof(GenreDto.Name));
            ViewData["AgeRatingIds"] = new SelectList(_ageRatingService.GetAgeRatings(),
                dataValueField: nameof(AgeRatingDto.Id),
                dataTextField: nameof(AgeRatingDto.Rating));
            return View("CreateOrUpdate", _filmService.FindById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(FilmDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            _filmService.CreateFilm(dto);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _filmService.DeleteById(id);

            return RedirectToAction("Index");
        }
    }
}
