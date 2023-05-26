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
    public class HotelRoomsController : ControllerBase
    {
        private readonly HotelContext _context;

        public HotelRoomsController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/HotelRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRooms>>> GetRooms()
        {
          if (_context.Rooms == null)
          {
              return NotFound();
          }
            return await _context.Rooms.ToListAsync();
        }

        // GET: api/HotelRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelRooms>> GetHotelRooms(int id)
        {
          if (_context.Rooms == null)
          {
              return NotFound();
          }
            var hotelRooms = await _context.Rooms.FindAsync(id);

            if (hotelRooms == null)
            {
                return NotFound();
            }

            return hotelRooms;
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelRooms(int id, HotelRooms hotelRooms)
        {
            if (id != hotelRooms.Room_Id)
            {
                return BadRequest();
            }

            _context.Entry(hotelRooms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelRoomsExists(id))
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

        // POST: api/HotelRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelRooms>> PostHotelRooms(HotelRooms hotelRooms)
        {
          if (_context.Rooms == null)
          {
              return Problem("Entity set 'HotelContext.Rooms'  is null.");
          }
            _context.Rooms.Add(hotelRooms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelRooms", new { id = hotelRooms.Room_Id }, hotelRooms);
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelRooms(int id)
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }
            var hotelRooms = await _context.Rooms.FindAsync(id);
            if (hotelRooms == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(hotelRooms);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelRoomsExists(int id)
        {
            return (_context.Rooms?.Any(e => e.Room_Id == id)).GetValueOrDefault();
        }
    }
}
