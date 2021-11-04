using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DaytaCare.Data;
using DaytaCare.Models;
using DaytaCare.Services;
using Microsoft.AspNetCore.Authorization;
using DaytaCare.Models.DTO;

namespace DaytaCare.Controllers
{
    [Authorize(Roles = "Administrator, Daycare Provider, Parent")]
    [Route("api/[controller]")]
    [ApiController]
    public class DaycaresController : ControllerBase
    {
        private readonly IDaycareRepository daycares;
        private readonly DaytaCareDbContext _context;

        public DaycaresController(IDaycareRepository daycares, DaytaCareDbContext context)
        {
            this.daycares = daycares;
            _context = context;
        }

        // GET: api/Daycares
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DaycareDTO>>> GetDaycares()
        {
            return await daycares.GetAll();
        }

        // GET: api/Daycares/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Daycare>> GetDaycare(int id)
        {
            var daycare = await daycares.GetById(id);

            if (daycare == null)
            {
                return NotFound();
            }

            return daycare;
        }

        // PUT: api/Daycares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administator, Daycare Provider")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDaycare(int id, Daycare daycare)
        {
            if (id != daycare.Id)
            {
                return BadRequest();
            }

            if (!await daycares.TryUpdate(daycare))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Daycares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrator, Daycare Provider")]
        [HttpPost]
        public async Task<ActionResult<Daycare>> PostDaycare(CreateDaycareDto data)
        {
            var daycare = await daycares.Insert(data);

            return CreatedAtAction("GetDaycare", new { id = daycare.Id }, daycare);
        }

        // DELETE: api/Daycares/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDaycare(int id)
        {
            var deleteSucceeded = await daycares.TryDelete(id);

            if (!deleteSucceeded)
            {
                return NotFound();
            }

            return NoContent();
        }

        private bool DaycareExists(int id)
        {
            return _context.Daycares.Any(e => e.Id == id);
        }

        [Authorize(Roles = "Administator, Daycare Provider")]
        [HttpPost]
        [Route("{id}/Amenities/{amenityId}")]
        public async Task<ActionResult<DaycareAmenity>> PostAmenity(int id, int amenityId)
        {
            await daycares.AddAmenity(id, amenityId);

            return NoContent();
        }

        [Authorize(Roles = "Administator, Daycare Provider")]
        [HttpDelete]
        [Route("{id}/Amenities/{amenityId}")]
        public async Task<ActionResult<DaycareAmenity>> DeleteAmenity(int id, int amenityId)
        {
            await daycares.DeleteAmenity(id, amenityId);

            return NoContent();
        }
    }
}
