using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hotel.models;
using hotel.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace hotel.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelStaffsController : ControllerBase
    {
        private readonly IHotelStaffs st;
        public HotelStaffsController(IHotelStaffs st)
        {
            this.st = st;
        }
        [HttpGet]
        public IEnumerable<HotelStaffs> Get()
        {
            return st.GetAllStaff();
        }

        [HttpGet("{id}")]
        public HotelStaffs GetById(int id)
        {
            return st.GetStaffById(id);
        }

        [HttpPost]
        public HotelStaffs PostStaff(HotelStaffs staff)
        {
            return st.PostStaff(staff);
        }
        [HttpPut("{id}")]
        public HotelStaffs PutStaff(int id, HotelStaffs staff)
        {
            return st.PutStaff(id, staff);
        }
        [HttpDelete("{id}")]
        public HotelStaffs DeleteStaff(int id)
        {
            return st.DeleteStaff(id);
        }

    }
}
