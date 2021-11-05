using DaytaCare.Controllers;
using DaytaCare.Models.DTO;
using DaytaCare.Models.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DaytaCare.Services.Identity
{
  public interface IUserService
  {

    Task<UserDTO> Register ( RegisterData data, ModelStateDictionary modelState );
    Task <UserDTO> DaycareRegister ( RegisterData data, ModelStateDictionary modelState );
    Task <UserDTO> Authenticate(LoginData data);
    Task <UserDTO> ParentRegister(ParentRegisterData data, ModelStateDictionary modelState);
    Task<UserDTO> GetCurrentUser ( );
    Task<UserDTO> GetUser ( ClaimsPrincipal principal );
    }
}
