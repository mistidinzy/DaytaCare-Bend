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

            modelBuilder.Entity<Amenity>()
                .HasData(
                new Amenity { Id = 1, Name = "Parking" },
                new Amenity { Id = 2, Name = "Indoor Playground" },
                new Amenity { Id = 3, Name = "Pay Scaling" },
                new Amenity { Id = 4, Name = "Shuttle Transportation" },
                new Amenity { Id = 5, Name = "Security" },
                new Amenity { Id = 6, Name = "Wheelchair Accessible" },
                new Amenity { Id = 7, Name = "Education" },
                new Amenity { Id = 8, Name = "Meal Plan" }
                );

            modelBuilder.Entity<Daycare>()
                .HasData(
                new Daycare { Id = 1, Name = "KidsPoint Downtown Learning Center & Preschool", StreetAddress = "318 5th St SE", City = "Cedar Rapids", State = "Iowa", Country = "United States", Phone = "(319) 365-1636", Email = "KidsPoint@example.com", Price = 200, DaycareType = DaycareType.LicensedCenter, LicenseNumber = 1, Availability = true },
                new Daycare { Id = 2, Name = "Teddy Bear Child Care Center Inc", StreetAddress = "2730 Bowling St SW", City = "Cedar Rapids", State = "Iowa", Country = "United States", Phone = "(319) 365-6534", Email = "TeddyBear@example.com", Price = 210, DaycareType = DaycareType.LicensedCenter, LicenseNumber = 2, Availability = true },
                new Daycare { Id = 3, Name = "Home Ties Child Care Center", StreetAddress = "405 Myrtle Ave", City = "Iowa City", State = "Iowa", Country = "United States", Phone = "(319) 341-0050", Email = "iowa4cshometies@yahoo.com", Price = 190, DaycareType = DaycareType.LicensedCenter, LicenseNumber = 3, Availability = true },
                new Daycare { Id = 4, Name = "Alice's Rainbow Child Care Center", StreetAddress = "421 Melrose Ave", City = "Iowa City", State = "Iowa", Country = "United States", Phone = "(319) 354-1466", Email = "alicesrainbowchildcarecenters@gmail.com", Price = 225, DaycareType = DaycareType.InHomeA, LicenseNumber = 4, Availability = false },
                new Daycare { Id = 5, Name = "KIDS INC.", StreetAddress = "1100 35th St", City = "Marion", State = "Iowa", Country = "United States", Phone = "(319) 447-6316", Email = "KidsInc@example.com", Price = 200, DaycareType = DaycareType.LicensedCenter, LicenseNumber = 5, Availability = true }
                );

            modelBuilder.Entity<DaycareAmenity>()
                .HasData(
                new DaycareAmenity { AmenityId = 1, DaycareId = 1 },
                new DaycareAmenity { AmenityId = 2, DaycareId = 1 },
                new DaycareAmenity { AmenityId = 3, DaycareId = 2 },
                new DaycareAmenity { AmenityId = 4, DaycareId = 2 },
                new DaycareAmenity { AmenityId = 5, DaycareId = 3 },
                new DaycareAmenity { AmenityId = 6, DaycareId = 3 },
                new DaycareAmenity { AmenityId = 7, DaycareId = 4 },
                new DaycareAmenity { AmenityId = 8, DaycareId = 5 },
                new DaycareAmenity { AmenityId = 5, DaycareId = 5 },
                new DaycareAmenity { AmenityId = 7, DaycareId = 2 },
                new DaycareAmenity { AmenityId = 6, DaycareId = 5 }

                );

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
