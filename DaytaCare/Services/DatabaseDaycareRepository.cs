using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DaytaCare.Data;
using DaytaCare.Models;
using Microsoft.EntityFrameworkCore;

namespace DaytaCare.Services
{
    public class DatabaseDaycareRepository : IDaycareRepository
    {
        private readonly DaytaCareDbContext _context;

        public DatabaseDaycareRepository(DaytaCareDbContext context)
        {
            _context = context;
        }

        public async Task<List<Daycare>> GetAll()
        {
            return await _context.Daycares.ToListAsync();
        }

        public async Task<Daycare> GetById(int id)
        {
            return await _context.Daycares.FindAsync(id);
        }

        public async Task Insert(Daycare daycare)
        {
            _context.Daycares.Add(daycare);
            await _context.SaveChangesAsync();
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
    }
}
