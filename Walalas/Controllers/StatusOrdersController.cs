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
    public class StatusOrdersController : ControllerBase
    {
        private readonly WalalaContext _context;

        public StatusOrdersController(WalalaContext context)
        {
            _context = context;
        }

        // GET: api/StatusOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusOrder>>> GetStatusOrder()
        {
            return await _context.StatusOrder.ToListAsync();
        }

        // GET: api/StatusOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusOrder>> GetStatusOrder(int id)
        {
            var statusOrder = await _context.StatusOrder.FindAsync(id);

            if (statusOrder == null)
            {
                return NotFound();
            }

            return statusOrder;
        }

        // PUT: api/StatusOrders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusOrder(int id, StatusOrder statusOrder)
        {
            if (id != statusOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(statusOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusOrderExists(id))
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

        // POST: api/StatusOrders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StatusOrder>> PostStatusOrder(StatusOrder statusOrder)
        {
            _context.StatusOrder.Add(statusOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusOrder", new { id = statusOrder.Id }, statusOrder);
        }

        // DELETE: api/StatusOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StatusOrder>> DeleteStatusOrder(int id)
        {
            var statusOrder = await _context.StatusOrder.FindAsync(id);
            if (statusOrder == null)
            {
                return NotFound();
            }

            _context.StatusOrder.Remove(statusOrder);
            await _context.SaveChangesAsync();

            return statusOrder;
        }

        private bool StatusOrderExists(int id)
        {
            return _context.StatusOrder.Any(e => e.Id == id);
        }
    }
}
