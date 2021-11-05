using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DaytaCare.Data;
using DaytaCare.Models;
using DaytaCare.Models.DTO;
using DaytaCare.Services.Identity;
using Microsoft.EntityFrameworkCore;

namespace DaytaCare.Services
{
    public class DatabaseDaycareRepository : IDaycareRepository
    {
        private readonly DaytaCareDbContext _context;
        private readonly IUserService userService;

        public DatabaseDaycareRepository(DaytaCareDbContext context, IUserService userService)
        {
            _context = context;
            this.userService = userService;
        }

        public async Task<List<DaycareDTO>> GetAll()
        {
            var user = await userService.GetCurrentUser();
            var result = await _context.Daycares
            .Where(daycare => daycare.OwnerId == user.UserId)
            .Select(daycare => new DaycareDTO
            {
                DaycareId = daycare.Id,

                Name = daycare.Name,

                DaycareType = daycare.DaycareType.ToString(),

                StreetAddress = daycare.StreetAddress,

                City = daycare.City,

                State = daycare.State,

                Country = daycare.Country,

                Phone = daycare.Phone,

                Email = daycare.Email,

                Price = daycare.Price,

                LicenseNumber = daycare.LicenseNumber,

                Availability = daycare.Availability,

                Amenities = daycare.DaycareAmenities
                    .Select(amenity => new AmenityDTO
                    {
                        AmenityId = amenity.Amenity.Id,
                        Name = amenity.Amenity.Name,
                    })
                .ToList()
            })

            .ToListAsync();

            return result;
        }

        public async Task<DaycareDTO> GetById(int id)
        {
            var user = await userService.GetCurrentUser();
            var result = await _context.Daycares
            .Where (daycare => daycare.OwnerId == user.UserId)
            .Select(daycare => new DaycareDTO
            {
                DaycareId = daycare.Id,

                Name = daycare.Name,

                DaycareType = daycare.DaycareType.ToString(),

                StreetAddress = daycare.StreetAddress,

                City = daycare.City,

                State = daycare.State,

                Country = daycare.Country,

                Phone = daycare.Phone,

                Email = daycare.Email,

                Price = daycare.Price,

                LicenseNumber = daycare.LicenseNumber,

                Availability = daycare.Availability,

                Amenities = daycare.DaycareAmenities
                    .Select(amenity => new AmenityDTO
                    {
                        AmenityId = amenity.Amenity.Id,
                        Name = amenity.Amenity.Name,
                    })

               .ToList()

            })

            .FirstOrDefaultAsync(d => d.DaycareId == id);

            return result;

        }
     

        public async Task<Daycare> Insert ( CreateDaycareDto data )
        {
            var user = await userService.GetCurrentUser();
            var daycare = new Daycare
            {
                Name = data.Name,
                StreetAddress = data.StreetAddress,
                City = data.City,
                State = data.State,
                Country = data.Country,
                Phone = data.Phone,
                Email = data.Email,
                Price = data.Price,
                LicenseNumber = data.LicenseNumber,
                Availability = data.Availability,
                OwnerId = user.UserId,
            };
            _context.Daycares.Add(daycare);

            await _context.SaveChangesAsync();
            return daycare;
        }

        public async Task<bool> TryDelete(int id)
        {
            var daycare = await _context.Daycares.FindAsync(id);
            if (daycare == null)
            {
                return false;
            }

            _context.Daycares.Remove(daycare);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TryUpdate(Daycare daycare)
        {
            _context.Entry(daycare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!DaycareExists(daycare.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        private bool DaycareExists(int id)
        {
            return _context.Daycares.Any(e => e.Id == id);
        }

        public async Task AddAmenity(int id, int amenityId)
        {
            var daycareAmenity = new DaycareAmenity
            {
                DaycareId = id,
                AmenityId = amenityId,
            };

            _context.DaycareAmenities.Add(daycareAmenity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAmenity(int id, int amenityId)
        {
            var daycareAmenity = await _context.DaycareAmenities

                .FirstOrDefaultAsync(e =>
                    e.DaycareId == id &&
                    e.AmenityId == amenityId);

            _context.DaycareAmenities.Remove(daycareAmenity);
            await _context.SaveChangesAsync();
        }
    }
}

