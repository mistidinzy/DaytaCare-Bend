using DaytaCare.Controllers;
using DaytaCare.Models.DTO;
using DaytaCare.Models.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace DaytaCare.Services.Identity
{
  public interface IUserService
  {

    Task<UserDTO> Register ( RegisterData data, ModelStateDictionary modelState );
    Task <DaycareRegisterDto> DaycareRegister ( DaycareRegisterData data, ModelStateDictionary modelState );
    Task <UserDTO> Authenticate(LoginData data);
    Task <UserDTO> ParentRegister(ParentRegisterData data, ModelStateDictionary modelState);
    }
}
