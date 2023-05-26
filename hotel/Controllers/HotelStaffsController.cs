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
    public class HotelStaffsController : ControllerBase
    {
        private readonly HotelContext _context;

        public HotelStaffsController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/HotelStaffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelStaffs>>> GetStaffs()
        {
          if (_context.Staffs == null)
          {
              return NotFound();
          }
            return await _context.Staffs.ToListAsync();
        }

        // GET: api/HotelStaffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelStaffs>> GetHotelStaffs(int id)
        {
          if (_context.Staffs == null)
          {
              return NotFound();
          }
            var hotelStaffs = await _context.Staffs.FindAsync(id);

            if (hotelStaffs == null)
            {
                return NotFound();
            }

            return hotelStaffs;
        }

        // PUT: api/HotelStaffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelStaffs(int id, HotelStaffs hotelStaffs)
        {
            if (id != hotelStaffs.Staff_Id)
            {
                return BadRequest();
            }

            _context.Entry(hotelStaffs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelStaffsExists(id))
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

        // POST: api/HotelStaffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelStaffs>> PostHotelStaffs(HotelStaffs hotelStaffs)
        {
          if (_context.Staffs == null)
          {
              return Problem("Entity set 'HotelContext.Staffs'  is null.");
          }
            _context.Staffs.Add(hotelStaffs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelStaffs", new { id = hotelStaffs.Staff_Id }, hotelStaffs);
        }

        // DELETE: api/HotelStaffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelStaffs(int id)
        {
            if (_context.Staffs == null)
            {
                return NotFound();
            }
            var hotelStaffs = await _context.Staffs.FindAsync(id);
            if (hotelStaffs == null)
            {
                return NotFound();
            }

            _context.Staffs.Remove(hotelStaffs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelStaffsExists(int id)
        {
            return (_context.Staffs?.Any(e => e.Staff_Id == id)).GetValueOrDefault();
        }
    }
}
