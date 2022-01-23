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
    public class PurchasedFilmController : Controller
    {
        private readonly IPurchasedFilmService _purchasedFilmService;
        private readonly IFilmService _filmService;
        private readonly IUserService _userService;
        public PurchasedFilmController(IFilmService filmService, IUserService userService,IPurchasedFilmService purchasedFilmService)
        {
            _userService = userService;
            _filmService = filmService;
            _purchasedFilmService = purchasedFilmService;
        }
        public ActionResult Index(int id)
        {
            return View(_purchasedFilmService.GetAllFilmsByUserId(id));
        }

        public ActionResult Buy()
        {
            ViewData["FilmIds"] = new SelectList(_filmService.GetFilms(),
                    dataValueField: nameof(FilmDto.Id),
                    dataTextField: nameof(FilmDto.Name));
            ViewData["UserIds"] = new SelectList(_userService.GetAllUsers(),
                    dataValueField: nameof(UserDto.Id),
                    dataTextField: nameof(UserDto.Login));

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(PurchasedFilmDto dto)
        {
            if (!_purchasedFilmService.Valid(dto))
            {

                ViewData["FilmIds"] = new SelectList(_filmService.GetFilms(),
                        dataValueField: nameof(FilmDto.Id),
                        dataTextField: nameof(FilmDto.Name));
                ViewData["UserIds"] = new SelectList(_userService.GetAllUsers(),
                        dataValueField: nameof(UserDto.Id),
                        dataTextField: nameof(UserDto.Login));
                return View(dto);
            }
            _purchasedFilmService.Create(dto);
            return RedirectToAction("Index", "Home");
        }
    }
}
