
using hotel.models;

namespace hotel.Repositories
{
    public interface IHotelCustomers
    {
        public IEnumerable<HotelCustomers> GetAllCustomer();
        public HotelCustomers GetCustomerById(int Customer_Id);
        public HotelCustomers PostCustomer(HotelCustomers Customer);
        public HotelCustomers PutCustomer(int Customer_Id, HotelCustomers Customer);
        public HotelCustomers DeleteCustomer(int Customer_Id);
    }
}
