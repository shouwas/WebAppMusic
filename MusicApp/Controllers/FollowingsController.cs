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
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _Context;

        public FollowingsController()
        {
            _Context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            var exists = _Context.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId == dto.FollowerId);

            if (exists)
            {
                return BadRequest("The following already exists.");
            }

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _Context.Followings.Add(following);
            _Context.SaveChanges();

            return Ok();
        }
    }
}
