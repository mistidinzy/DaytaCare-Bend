using DaytaCare.Models.DTO;
using DaytaCare.Models.Identity;
using DaytaCare.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaytaCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterData data)
        {
            var user = await userService.Register(data, this.ModelState);
            if (user == null)
                return BadRequest(new ValidationProblemDetails(ModelState)
                  );
            return user;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginData data)
        {
            var user = await userService.Authenticate(data);

            if (user == null)
                return Unauthorized();

            return user;
        }

        [HttpPost("DaycareRegister")]
        public async Task<ActionResult<UserDTO>> DaycareRegister(RegisterData data)
        {
            var user = await userService.DaycareRegister(data, this.ModelState);
            if (user == null)
                return BadRequest(new ValidationProblemDetails(ModelState)
                  );
            return Ok(user);
        }

        [HttpPost("ParentRegister")]
        public async Task<IActionResult> ParentRegister(ParentRegisterData data)
        {
            var user = await userService.ParentRegister(data, this.ModelState);
            if (user == null)
                return BadRequest(new ValidationProblemDetails(ModelState)
                  );
            return Ok(user);
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<ActionResult<UserDTO>> Self()
        {
            var user = await userService.GetCurrentUser();
            return (user);
            //return Ok();
        }
    }
}
