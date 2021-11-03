using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DaytaCare.Models;
using DaytaCare.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DaytaCare.Controllers
{
    [Authorize("Administrator, Parent")]
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly object context;

        public async Task<ActionResult<List<Daycare>>> Search(ParentSearchDto filter)
        {

            IQueryable<Daycare> query = context.Daycares;

            if (filter.City != null)
                query = query.Where(d => d.City == filter.City);

            if (filter.State != null)
                query = query.Where(d => d.State == filter.State);

            List<Daycare> results = await query.ToListAsync();

        } 
    }
}