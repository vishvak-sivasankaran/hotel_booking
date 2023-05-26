using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hotel.models;
using hotel.Repositories;

namespace hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRooms st;
        public HotelRoomsController(IHotelRooms st)
        {
            this.st = st;
        }
        [HttpGet]
        public IEnumerable<HotelRooms> Get()
        {
            return st.GetAllRoom();
        }

        [HttpGet("{id}")]
        public HotelRooms GetById(int id)
        {
            return st.GetRoomById(id);
        }

        [HttpPost]
        public HotelRooms PostRoom(HotelRooms Room)
        {
            return st.PostRoom(Room);
        }
        [HttpPut("{id}")]
        public HotelRooms PutRoom(int id, HotelRooms Room)
        {
            return st.PutRoom(id, Room);
        }
        [HttpDelete("{id}")]
        public HotelRooms DeleteRoom(int id)
        {
            return st.DeleteRoom(id);
        }

    }
}
