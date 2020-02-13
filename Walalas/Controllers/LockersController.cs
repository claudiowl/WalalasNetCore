using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Walalas.Api.Contexts;
using Walalas.Api.Models;

namespace Walalas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LockersController : ControllerBase
    {
        private readonly WalalaContext _context;

        public LockersController(WalalaContext context)
        {
            _context = context;
        }

        // GET: api/Lockers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locker>>> GetLocker()
        {
            return await _context.Locker.ToListAsync();
        }

        // GET: api/Lockers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Locker>> GetLocker(int id)
        {
            var locker = await _context.Locker.FindAsync(id);

            if (locker == null)
            {
                return NotFound();
            }

            return locker;
        }

        // PUT: api/Lockers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocker(int id, Locker locker)
        {
            if (id != locker.IdNumber)
            {
                return BadRequest();
            }

            _context.Entry(locker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LockerExists(id))
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

        // POST: api/Lockers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Locker>> PostLocker(Locker locker)
        {
            _context.Locker.Add(locker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocker", new { id = locker.IdNumber }, locker);
        }

        // DELETE: api/Lockers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Locker>> DeleteLocker(int id)
        {
            var locker = await _context.Locker.FindAsync(id);
            if (locker == null)
            {
                return NotFound();
            }

            _context.Locker.Remove(locker);
            await _context.SaveChangesAsync();

            return locker;
        }

        private bool LockerExists(int id)
        {
            return _context.Locker.Any(e => e.IdNumber == id);
        }
    }
}
