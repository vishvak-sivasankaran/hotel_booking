using hotel.models;
using Microsoft.EntityFrameworkCore;

namespace hotel.Repositories
{
    public class HotelCustomersRepositories : IHotelCustomers
    {
        private readonly HotelContext _CustomerContext;
        public HotelCustomersRepositories(HotelContext context)
        {
            _CustomerContext = context;
        }
        //GetAllCustomer
        public IEnumerable<HotelCustomers> GetAllCustomer()
        {
            return _CustomerContext.Customers.ToList();
        }
        //GetCustomerById
        public HotelCustomers GetCustomerById(int Customer_Id)
        {
            return _CustomerContext.Customers.FirstOrDefault(x => x.Cus_id == Customer_Id);
        }
        //PostCustomer
        public HotelCustomers PostCustomer(HotelCustomers Customer)
        {
            var st = _CustomerContext.Hotels.Find(Customer.Hotels.Hotel_Id);
            Customer.Hotels = st;
            _CustomerContext.Add(Customer);
            _CustomerContext.SaveChanges();
            return Customer;
        }
        //PutCustomer
        public HotelCustomers PutCustomer(int Customer_Id, HotelCustomers Customer)
        {
            var st = _CustomerContext.Hotels.Find(Customer.Hotels.Hotel_Id);
            Customer.Hotels = st;
            _CustomerContext.Entry(Customer).State = EntityState.Modified;
            _CustomerContext.SaveChangesAsync();
            return Customer;
        }
        //DeletCustomer
        public HotelCustomers DeleteCustomer(int cus_Id)
        {
            var st = _CustomerContext.Customers.Find(cus_Id);
            _CustomerContext.Customers.Remove(st);
            _CustomerContext.SaveChanges();
            return st;
        }
    }
}