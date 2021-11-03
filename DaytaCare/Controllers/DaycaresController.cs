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

namespace DaytaCare.Controllers
{
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Daycare>>> GetDaycares()
        {
            return await _context.Daycares.ToListAsync();
        }

        // GET: api/Daycares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Daycare>> GetDaycare(int id)
        {
            var daycare = await _context.Daycares.FindAsync(id);

            if (daycare == null)
            {
                return NotFound();
            }

            return daycare;
        }

        // PUT: api/Daycares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDaycare(int id, Daycare daycare)
        {
            if (id != daycare.Id)
            {
                return BadRequest();
            }

            _context.Entry(daycare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DaycareExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Daycares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Daycare>> PostDaycare(Daycare daycare)
        {
            _context.Daycares.Add(daycare);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDaycare", new { id = daycare.Id }, daycare);
        }

        // DELETE: api/Daycares/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDaycare(int id)
        {
            var daycare = await _context.Daycares.FindAsync(id);
            if (daycare == null)
            {
                return NotFound();
            }

            _context.Daycares.Remove(daycare);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DaycareExists(int id)
        {
            return _context.Daycares.Any(e => e.Id == id);
        }
    }
}
