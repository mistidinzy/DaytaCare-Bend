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
    public string FamilyBio { get; set; }
  }
}
