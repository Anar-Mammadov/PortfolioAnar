using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.Model.Entity;
using Portfolio.WebUI.Model.Entity.Memvership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Model.DataContexts
{
    public class PortfolioDbContext :IdentityDbContext<PortUser,PortRole,int,PortUserClaim,PortUserRole,PortUserLogin,PortRoleClaim,PortUserToken>
    {
        public PortfolioDbContext(DbContextOptions options)
            :base(options)
        {
        
        }
        public DbSet<Contact> Contactss { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public DbSet<Education> Educations { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<Icon> Icons { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<AboutMe> Aboutme { get; set; }


    }
}
