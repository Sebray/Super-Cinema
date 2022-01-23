using Buisness.Interop.Data;
using Buisness.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Cinema.Views
{
    public class RegionController : Controller
    {
        private readonly IRegionService _regionService;
        
        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }
        
        // GET: RegionController
        public ActionResult Index()
        {
            var regions =_regionService.GetRegions();
            return View(regions);
        }

        // GET: RegionController/Create
        public ActionResult Create()
        {
            return View("CreateOrUpdate");
        }

        // POST: RegionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegionDto dto)
        {
            _regionService.Create(dto);


            return RedirectToAction(nameof(Index));

        }

        // Get: RegionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View("CreateOrUpdate", _regionService.FindById(id));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(RegionDto dto)
        {
            if(!ModelState.IsValid ||( dto.Id == 0 && _regionService.ExistName(dto.Name)))
            {
                return View(dto);
            }
            _regionService.Create(dto);

            return RedirectToAction("Index");
        }
    }
}
