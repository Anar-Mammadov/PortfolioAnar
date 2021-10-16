﻿using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Model.DataContexts
{
    public class PortfolioDbContext :DbContext
    {
        public PortfolioDbContext(DbContextOptions options)
            :base(options)
        {
        
        }
        public DbSet<Contact> Contactss { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}