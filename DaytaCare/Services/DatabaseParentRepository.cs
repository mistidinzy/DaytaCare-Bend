using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DaytaCare.Data;
using DaytaCare.Models;
using DaytaCare.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DaytaCare.Services
{
    public class DatabaseParentRepository : IParentRepository
    {
        private readonly DaytaCareDbContext _context;

        public DatabaseParentRepository(DaytaCareDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Daycare>>> Search(ParentSearchDto filter)
        {
            IQueryable<Daycare> query = _context.Daycares;

            if (filter.City != null)
                query = query.Where(d => d.City == filter.City);

            if (filter.State != null)
                query = query.Where(d => d.State == filter.State);

            if (filter.AmenityId != null)
                query = query.Where(d => d.DaycareAmenities.Any(a => a.AmenityId == filter.AmenityId));

            if (filter.Availability != null)
                query = query.Where(d => d.Availability == filter.Availability);

            List<Daycare> results = await query.ToListAsync();

            return results;
        }
    }
}

