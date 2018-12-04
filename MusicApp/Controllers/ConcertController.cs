using MusicApp.Models;
using MusicApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicApp.Controllers
{
    public class ConcertController : Controller
    {

        private readonly ApplicationDbContext _Context;

        public ConcertController()
        {
            _Context = new ApplicationDbContext();
        }

        // GET: Concert
        public ActionResult Create()
        {
            var ViewModel = new ConcertFormViewModel
            {
                Genres = _Context.Genre.ToList()
            };

            return View(ViewModel);
        }
    }
}