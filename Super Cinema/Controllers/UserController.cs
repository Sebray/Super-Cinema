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
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICityService _cityService;
        
        public UserController(IUserService userService,ICityService cityService)
        {
            _userService = userService;
            _cityService = cityService;
        }
        
        // GET: UserController
        public ActionResult Index()
        {
            return View( _userService.GetAllUsers());
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View(_userService.FindById(id));
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            ViewData["CityIds"] = new SelectList(_cityService.GetCities(),
                    dataValueField: nameof(CityDto.Id),
                    dataTextField: nameof(CityDto.Name));
            return View("CreateOrUpdate");
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["CityIds"] = new SelectList(_cityService.GetCities(),
                    dataValueField: nameof(CityDto.Id),
                    dataTextField: nameof(CityDto.Name));
            return View("CreateOrUpdate", _userService.FindById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(UserDto dto)
        {
           if (!ModelState.IsValid || (dto.Id == 0 && _userService.ExistByLogin(dto.Login)))
            {
                ViewData["CityIds"] = new SelectList(_cityService.GetCities(),
                    dataValueField: nameof(CityDto.Id),
                    dataTextField: nameof(CityDto.Name));
                return View(dto);
            }
            _userService.CreateUser(dto);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _userService.DeleteById(id);

            return RedirectToAction("Index");
        }
        public FileResult GetXlsx()
        {
            return File(_userService.GetXlsx().ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Доходы от покупки фильмов.xlsx");
        }
    }
}
