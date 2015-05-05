using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wurl.Data.Model;

namespace Wurl.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() 
            : base("WurlApiConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<LookUp> LookupTable { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<EventLookUp> EventLookTable { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Attendance> Attendees { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
