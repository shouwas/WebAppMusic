
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MusicApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Genre> Genre { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}