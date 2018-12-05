using Microsoft.AspNet.Identity;
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
        [Authorize]
        public ActionResult Create()
        {
            var ViewModel = new ConcertFormViewModel
            {
                Genres = _Context.Genre.ToList()
            };

            return View(ViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(ConcertFormViewModel viewModel)
        {

            var concert = new Concert
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.DateTime,
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            _Context.Concerts.Add(concert);
            _Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}