using Microsoft.AspNet.Identity;
using MusicApp.Dtos;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicApp.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _Context;

        public AttendancesController()
        {
            _Context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var UserId = User.Identity.GetUserId();
            var exists = _Context.Attendances.Any(a => a.AttendeeId == UserId && a.ConcertId == dto.ConcertId);

            if(exists)
            {
                return BadRequest("The attendance already exists.");
            }

            var attendance = new Attendance
            {
                ConcertId = dto.ConcertId,
                AttendeeId = UserId
            };
            _Context.Attendances.Add(attendance);
            _Context.SaveChanges();

            return Ok();

        }
    }
}
