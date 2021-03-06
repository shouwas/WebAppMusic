﻿using Microsoft.AspNet.Identity;
using MusicApp.Models;
using MusicApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var concerts = _Context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Concert)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();

            var viewModel = new HomeViewModel()
            {
                UpcomingConcerts = concerts,
                ShowActions = User.Identity.IsAuthenticated
            };

            return View(viewModel);
        }

        // GET: Concert
        [Authorize]
        public ActionResult Create()
        {
            var ViewModel = new ConcertFormViewModel
            {
                Genres = _Context.Genre.ToList(),
            };

            return View(ViewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConcertFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _Context.Genre.ToList();
                return View("Create", viewModel);
            }

            var concert = new Concert
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            _Context.Concerts.Add(concert);
            _Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}