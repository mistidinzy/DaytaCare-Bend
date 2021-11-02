using System;
using DaytaCare.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DaytaCare.Data
{
    public class DaytaCareDbContext : IdentityDbContext<ApplicationUser>
    {
        public DaytaCareDbContext(DbContextOptions options) : base(options)
        {
        }
    protected override void OnModelCreating ( ModelBuilder modelbuilder )
    {
      base.OnModelCreating(modelbuilder);
    }
  }
}
