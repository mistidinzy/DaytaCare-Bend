using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DaytaCare.Models;
using DaytaCare.Models.DTO;
using DaytaCare.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DaytaCare.Controllers
{ 
    [Authorize(Roles = "Administrator, Parent")]
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly IParentRepository daycares;

        public ParentsController(IParentRepository daycares)
        {
            this.daycares = daycares;
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<DaycareDTO>>> Search([FromQuery]ParentSearchDto filter)
        {
            return await daycares.Search(filter);
        }
    }
}
