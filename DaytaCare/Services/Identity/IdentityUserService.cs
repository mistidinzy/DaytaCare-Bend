using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaytaCare.Services.Identity
{
  public class IdentityUserService : IUserService
  {
    public IActionResult Index ( )
    {
      return View();
    }
  }
}




