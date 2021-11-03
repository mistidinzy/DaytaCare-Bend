using DaytaCare.Controllers;
using DaytaCare.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaytaCare.Services.Identity
{
  public class IdentityUserService : IUserService
  {
    private readonly UserManager<ApplicationUser> userManager;
    public IdentityUserService(UserManager<ApplicationUser> userManager)
    {
      this.userManager = userManager;
    }

    public async Task<ApplicationUser> DaycareRegister ( DaycareRegisterData data, ModelStateDictionary modelState )
    {
      var user = new ApplicationUser
      {
        UserName = data.Username,
        Name = data.Name,
        LicenseNumber = data.LicenseNumber,
        Email = data.Email,
        StreetAddress = data.StreetAddress,
        City = data.City,
        State = data.State,
        Zip = data.Zip,
        PhoneNumber = data.Phone,
        Price = data.Price,
      };
      var result = await userManager.CreateAsync(user, data.Password);

      if(result.Succeeded)
      {
        return user;
      }
      foreach (var error in result.Errors)
      {
        var errorKey =
          error.Code.Contains("Password") ? nameof(data.Password) :
          error.Code.Contains("Email") ? nameof(data.Email) :
          error.Code.Contains("UserName") ? nameof(data.Username) :
          "";
        modelState.AddModelError(errorKey, error.Description);
      }
      return null;
    }

    public async Task<ApplicationUser> Register (RegisterData data, ModelStateDictionary modelState )
    {
      var user = new ApplicationUser
      {
        Email = data.Email,
        UserName = data.Username,
      };
      var result = await userManager.CreateAsync(user, data.Password);

      if(result.Succeeded)
      {
        return user;
      }
      foreach (var error in result.Errors)
      {
        var errorKey =
            error.Code.Contains("Password") ? nameof(data.Password) :
            error.Code.Contains("Email") ? nameof(data.Email) :
            error.Code.Contains("UserName") ? nameof(data.Username) :
            "";
        modelState.AddModelError(errorKey, error.Description);
      }
      return null;
    }
  }
}




