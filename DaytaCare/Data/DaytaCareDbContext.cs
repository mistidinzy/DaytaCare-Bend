using System;
using Microsoft.EntityFrameworkCore;

namespace DaytaCare.Data
{
    public class DaytaCareDbContext : DbContext
    {
        public DaytaCareDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
