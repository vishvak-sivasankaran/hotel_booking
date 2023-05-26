using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hotel.models;

namespace hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelCustomersController : ControllerBase
    {
        private readonly HotelContext _context;

        public HotelCustomersController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/HotelCustomers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelCustomers>>> GetCustomers()
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            return await _context.Customers.ToListAsync();
        }

        // GET: api/HotelCustomers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelCustomers>> GetHotelCustomers(int id)
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            var hotelCustomers = await _context.Customers.FindAsync(id);

            if (hotelCustomers == null)
            {
                return NotFound();
            }

            return hotelCustomers;
        }

        // PUT: api/HotelCustomers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelCustomers(int id, HotelCustomers hotelCustomers)
        {
            if (id != hotelCustomers.Cus_id)
            {
                return BadRequest();
            }

            _context.Entry(hotelCustomers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelCustomersExists(id))
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

        // POST: api/HotelCustomers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelCustomers>> PostHotelCustomers(HotelCustomers hotelCustomers)
        {
          if (_context.Customers == null)
          {
              return Problem("Entity set 'HotelContext.Customers'  is null.");
          }
            _context.Customers.Add(hotelCustomers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelCustomers", new { id = hotelCustomers.Cus_id }, hotelCustomers);
        }

        // DELETE: api/HotelCustomers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelCustomers(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var hotelCustomers = await _context.Customers.FindAsync(id);
            if (hotelCustomers == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(hotelCustomers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelCustomersExists(int id)
        {
            return (_context.Customers?.Any(e => e.Cus_id == id)).GetValueOrDefault();
        }
    }
}
