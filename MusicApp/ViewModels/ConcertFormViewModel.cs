using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicApp.ViewModels
{
    public class ConcertFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
 //       [FuturDate]
        public string Date { get; set; }

        [Required]
        [ValidationTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        
        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(String.Format("{0} {1}", Date, Time)); 
        }
    }
}