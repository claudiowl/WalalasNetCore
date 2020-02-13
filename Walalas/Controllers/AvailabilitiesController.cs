using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Walalas.Api.Contexts;
using Walalas.Api.Models;

namespace Walalas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilitiesController : ControllerBase
    {
        private readonly WalalaContext _context;

        public AvailabilitiesController(WalalaContext context)
        {
            _context = context;
        }

        // GET: api/Availabilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Availability>>> GetAvaibality()
        {
            var availabilities = await _context.Avaibality.ToListAsync();
            if (availabilities == null)
            {
                return NotFound();
            }
            else
            {
                return availabilities;

            }
        }

        // GET: api/Availabilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Availability>> GetAvailability(int id)
        {
            var availability = await _context.Avaibality.FindAsync(id);

            if (availability == null)
            {
                return NotFound();
            }

            return availability;
        }

        // PUT: api/Availabilities/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvailability(int id, Availability availability)
        {
            if (id != availability.Id)
            {
                return BadRequest();
            }

            _context.Entry(availability).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvailabilityExists(id))
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

        // POST: api/Availabilities
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Availability>> PostAvailability(Availability availability)
        {
            _context.Avaibality.Add(availability);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvailability", new { id = availability.Id }, availability);
        }

        // DELETE: api/Availabilities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Availability>> DeleteAvailability(int id)
        {
            var availability = await _context.Avaibality.FindAsync(id);
            if (availability == null)
            {
                return NotFound();
            }

            _context.Avaibality.Remove(availability);
            await _context.SaveChangesAsync();

            return availability;
        }

        private bool AvailabilityExists(int id)
        {
            return _context.Avaibality.Any(e => e.Id == id);
        }


        [HttpOptions]
        public IActionResult AvailabilityOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }
    }
}
