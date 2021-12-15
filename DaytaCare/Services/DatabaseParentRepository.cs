using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DaytaCare.Data;
using DaytaCare.Models;
using DaytaCare.Models.DTO;
using DaytaCare.Services.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DaytaCare.Services
{
    public class DatabaseParentRepository : IParentRepository
    {
        private readonly DaytaCareDbContext _context;
        private readonly IUserService userService;

        public DatabaseParentRepository(DaytaCareDbContext context, IUserService userService)
        {
            _context = context;
            this.userService = userService;
        }

        public async Task<ActionResult<List<DaycareDTO>>> Search(ParentSearchDto filter)
        {
            IQueryable<Daycare> query = _context.Daycares;

            if (filter.City != null)
                query = query
                    .Where(d => d.City == filter.City);

            if (filter.State != null)
                query = query
                    .Where(d => d.State == filter.State);

            if (filter.AmenityId != null)
                query = query
                    .Where(d => d.DaycareAmenities
                        .Any(a => filter.AmenityId
                            .Contains(a.AmenityId)));

            if (filter.Availability != null)
                query = query
                    .Where(d => d.Availability == filter.Availability);

            if (filter.DaycareType != null)
                query = query
                    .Where(d => filter.DaycareType
                        .Contains(d.DaycareType));

            List<DaycareDTO> results = await query
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

            return results;
        }

        public async Task<DaycareDTO> GetById(int id)
        {
            var result = await _context.Daycares
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
    }
}
