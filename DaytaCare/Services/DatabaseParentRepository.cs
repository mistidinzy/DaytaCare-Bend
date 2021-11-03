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
    public class DatabaseParentRepository
    {
        private readonly DaytaCareDbContext context;

        public DatabaseParentRepository(DaytaCareDbContext _context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Daycare>>> Search(ParentSearchDto filter)
        {
            IQueryable<Daycare> query = context.Daycares;

            if (filter.City != null)
                query = query.Where(d => d.City == filter.City);

            if (filter.State != null)
                query = query.Where(d => d.State == filter.State);

            List<Daycare> results = await query.ToListAsync();
        }
    }
}
