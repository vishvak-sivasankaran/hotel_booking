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
    public class HotelsController : ControllerBase
    {
        private readonly IHotels st;
        public HotelsController(IHotels st)
        {
            this.st = st;
        }
        [HttpGet]
        public IEnumerable<Hotels> GetAll()
        {
            return st.GetAllhotel();
        }

        [HttpGet("{id}")]
        public Hotels GetById(int id)
        {
            return st.GethotelById(id);
        }

        [HttpPost]
        public Hotels Post(Hotels hotels)
        {
            return st.Posthotel(hotels); ;
        }
        [HttpPut("{id}")]
        public Hotels Put(int id, Hotels hotels)
        {
            return st.Puthotel(id,hotels);
        }
        [HttpDelete("{id}")]
        public Hotels Delete(int id)
        {
            return st.Deletehotel(id);
        }

    }
}
