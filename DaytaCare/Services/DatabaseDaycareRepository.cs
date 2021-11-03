using System;
using DaytaCare.Data;

namespace DaytaCare.Services
{
    public class DatabaseDaycareRepository : IDaycareRepository
    {
        private readonly DaytaCareDbContext _context;

        public DatabaseDaycareRepository(DaytaCareDbContext context)
        {
            _context = context;
        }
    }
}
