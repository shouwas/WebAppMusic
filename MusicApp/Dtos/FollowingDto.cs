using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Dtos
{
    public class FollowingDto
    {
        public string FollowerId { get; set; }
        public string FolloweeId { get; set; }
    }
}