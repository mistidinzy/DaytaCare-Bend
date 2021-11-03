using DaytaCare.Controllers;
using DaytaCare.Models.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace DaytaCare.Services.Identity
{
  public interface IUserService
  {
    Task<ApplicationUser> Register ( RegisterData data, ModelStateDictionary modelState );
    Task <ApplicationUser> DaycareRegister ( DaycareRegisterData data, ModelStateDictionary modelState );
  }
}
