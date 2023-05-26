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
    public class HotelCustomersController : ControllerBase
    {
        private readonly IHotelCustomers st;
        public HotelCustomersController(IHotelCustomers st)
        {
            this.st = st;
        }
        [HttpGet]
        public IEnumerable<HotelCustomers> Get()
        {
            return st.GetAllCustomer();
        }

        [HttpGet("{id}")]
        public HotelCustomers GetById(int id)
        {
            return st.GetCustomerById(id);
        }

        [HttpPost]
        public HotelCustomers Postcustomer(HotelCustomers customer)
        {
            return st.PostCustomer(customer);
        }
        [HttpPut("{id}")]
        public HotelCustomers Putcustomer(int id, HotelCustomers customer)
        {
            return st.PutCustomer(id, customer);
        }
        [HttpDelete("{id}")]
        public HotelCustomers Deletecustomer(int id)
        {
            return st.DeleteCustomer(id);
        }

    }
}