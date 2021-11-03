﻿using System;
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
    }
}
