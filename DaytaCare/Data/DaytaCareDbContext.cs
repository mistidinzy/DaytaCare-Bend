using System;
using DaytaCare.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DaytaCare.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DaytaCare.Data
{
    public class DaytaCareDbContext : IdentityDbContext<ApplicationUser>
    {
        public DaytaCareDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Daycare> Daycares { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<DaycareAmenity> DaycareAmenities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DaycareAmenity>()
                .HasKey(da => new { da.DaycareId, da.AmenityId }

            );

            SeedRole(modelBuilder, "Administrator");
            SeedRole(modelBuilder, "Parent");
            SeedRole(modelBuilder, "Daycare Provider");
        }

        private void SeedRole(ModelBuilder modelBuilder, string roleName)
        {
            var role = new IdentityRole
            {
                Id = roleName,
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString(),
            };

            modelBuilder.Entity<IdentityRole>().HasData(role);
        }
    }
}
