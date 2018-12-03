using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicApp.Controllers
{
    public class ConcertController : Controller
    {
        // GET: Concert
        public ActionResult Create()
        {
            return View();
        }
    }
}