using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DaytaCare.Models.Identity
{
  public class ApplicationUser : IdentityUser
  {
    //[Required]
    public string FirstName {get; set;}

    //[Required]
    public string LastName { get; set; }
    public string Name { get; set; }
    public string LicenseNumber { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public decimal Price { get; set; }
    public string FamilyBio { get; set; }
  }
}
