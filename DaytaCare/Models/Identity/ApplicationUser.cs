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
    public string Name { get; internal set; }
    public string LicenseNumber { get; internal set; }
    public string StreetAddress { get; internal set; }
    public string City { get; internal set; }
    public string State { get; internal set; }
    public string Zip { get; internal set; }
    public decimal Price { get; internal set; }
  }
}
