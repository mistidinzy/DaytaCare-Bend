using System;
using DaytaCare.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using DaytaCare.Models;
using Microsoft.EntityFrameworkCore;

namespace DaytaCare.Data
{
    public class DaytaCareDbContext : IdentityDbContext<ApplicationUser>
    {
        public DaytaCareDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Daycare> Daycares { get; set; }
        public DbSet<Amenity> Amenities { get; set; }


        protected override void OnModelCreating ( ModelBuilder modelbuilder )
    {
      base.OnModelCreating(modelbuilder);
    }
  }
}