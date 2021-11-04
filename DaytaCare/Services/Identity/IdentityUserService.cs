using DaytaCare.Controllers;
using DaytaCare.Models.DTO;
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
        private readonly JwtService jwtService;

        public IdentityUserService(UserManager<ApplicationUser> userManager, JwtService jwtService)
        {
            this.userManager = userManager;
            this.jwtService = jwtService;
        }

        public async Task<UserDTO> Authenticate(LoginData data)
        {
            var user = await userManager.FindByNameAsync(data.Username);
            if (!await userManager.CheckPasswordAsync(user, data.Password))
                return null;

            return await CreateUserDTOAsync(user);
        }

        public async Task<UserDTO> DaycareRegister(RegisterData data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                Email = data.Email,
                UserName = data.Username
            };
            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Daycare Provider");
                return await CreateUserDTOAsync(user);
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

        private Task<DaycareRegisterDto> CreateDaycareRegisterDtoAsync ( ApplicationUser user )
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> Register(RegisterData data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                Email = data.Email,
                UserName = data.Username,
            };
            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
               
                await userManager.AddToRoleAsync(user, "Administrator");
                return await CreateUserDTOAsync(user);
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

        private async Task<UserDTO> CreateUserDTOAsync(ApplicationUser user)
        {
            return new UserDTO
            {
                UserId = user.Id,
                Email = user.Email,
                Username = user.UserName,

                Roles = await userManager.GetRolesAsync(user),

                Token = await jwtService.GetToken(user, TimeSpan.FromMinutes(5)),
            };
        }

        public async Task<UserDTO> ParentRegister(ParentRegisterData data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                FirstName = data.FirstName,
                LastName = data.LastName,
                PhoneNumber = data.Phone,
                FamilyBio = data.FamilyBio,
            };

            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Parent");
                return await CreateUserDTOAsync(user);
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
