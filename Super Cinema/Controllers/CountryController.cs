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
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IRegionService _regionService;
        
        public CountryController(ICountryService countryService, IRegionService regionService)
        {
            _regionService = regionService;
            _countryService = countryService;
        }

        // GET: CountryController
        public ActionResult Index()
        {
            var countries = _countryService.GetCountries();
            return View(countries);
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            ViewData["RegionIds"] = new SelectList(_regionService.GetRegions(),
                    dataValueField: nameof(CityDto.Id),
                    dataTextField: nameof(CityDto.Name));
            return View("CreateOrUpdate");
        }

        // Get: CountryController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["RegionIds"] = new SelectList(_regionService.GetRegions(),
                    dataValueField: nameof(CityDto.Id),
                    dataTextField: nameof(CityDto.Name));

            return View("CreateOrUpdate", _countryService.FindById(id));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(CountryDto dto)
        {
            if (!ModelState.IsValid || (dto.Id == 0 && _countryService.ExistName(dto.Name)))
            {
                ViewData["RegionIds"] = new SelectList(_regionService.GetRegions(),
                    dataValueField: nameof(RegionDto.Id),
                    dataTextField: nameof(RegionDto.Name));
                return View(dto);
            }
            _countryService.Create(dto);

            return RedirectToAction("Index");
        }
    }
}
