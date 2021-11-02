using System;
using DaytaCare.Models;
using Microsoft.EntityFrameworkCore;

namespace DaytaCare.Data
{
    public class DaytaCareDbContext : DbContext
    {
        public DaytaCareDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Daycare> Daycares { get; set; }

    }
}
