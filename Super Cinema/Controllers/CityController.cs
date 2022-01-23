using Buisness.Interop.Data;
using Buisness.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Cinema.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public CityController(ICityService cityService, ICountryService countryService)
        {
            _countryService = countryService;
            _cityService = cityService;
        }

        // GET: CityController
        public ActionResult Index()
        {
            var cities = _cityService.GetCities();
            return View(cities);
        }

        // GET: CityController/Create
        public ActionResult Create()
        {
            ViewData["CountryIds"] = new SelectList(_countryService.GetCountries(),
                    dataValueField: nameof(CountryDto.Id),
                    dataTextField: nameof(CountryDto.Name));
            return View("CreateOrUpdate");
        }

        // Get: CityController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["CountryIds"] = new SelectList(_countryService.GetCountries(),
                    dataValueField: nameof(CountryDto.Id),
                    dataTextField: nameof(CountryDto.Name));

            return View("CreateOrUpdate", _cityService.FindById(id));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(CityDto dto)
        {
            if (!ModelState.IsValid || (dto.Id == 0 && _cityService.ExistName(dto.Name)))
            {
                ViewData["CountryIds"] = new SelectList(_countryService.GetCountries(),
                    dataValueField: nameof(CountryDto.Id),
                    dataTextField: nameof(CountryDto.Name));
                return View(dto);
            }
            _cityService.Create(dto);

            return RedirectToAction("Index");
        }
    }
}
