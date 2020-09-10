using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Petrovskaya_90311.DAL.Entities;

namespace Petrovskaya_90311.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalGroup> AnimalGroups { get; set; }

        public
        ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
    }
}
