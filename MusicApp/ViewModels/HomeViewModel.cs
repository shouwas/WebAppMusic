using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Concert> UpcomingConcerts { get; set; }
        public bool ShowActions { get; set; }
    }
}