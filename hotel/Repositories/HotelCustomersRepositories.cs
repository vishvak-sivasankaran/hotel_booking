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
        public IEnumerable<Hotels> FilterLocation(string location)
        {
            try
            {
                var location_query = _CustomerContext.Hotels.Include(x => x.Hotel_Rooms).AsQueryable();

                if (!string.IsNullOrEmpty(location))
                {
                    location_query = location_query.Where(h => h.Hotel_Location.Contains(location));
                }
                return location_query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while filtering the location.", ex);
            }
        }
        //Filtering amenities
        public IEnumerable<Hotels> FilterAmenities(string amenities)
        {
            try
            {
                var amenities_query = _CustomerContext.Hotels.Include(x => x.Hotel_Rooms).AsQueryable();

                if (!string.IsNullOrEmpty(amenities))
                {
                    amenities_query = amenities_query.Where(h => h.Hotel_amenities.Contains(amenities));
                }
                return amenities_query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while filtering the amenties.", ex);
            }
        }
        // Filtering price range
        public IEnumerable<Hotels> FilterPriceRange(decimal minPrice, decimal maxPrice)
        {
            try
            {
                var priceQuery = _CustomerContext.Hotels.Include(x => x.Hotel_Rooms).AsQueryable();

                if (minPrice > 0)
                {
                    priceQuery = priceQuery.Where(r => r.Hotel_Price >= minPrice);
                }

                if (maxPrice > 0)
                {
                    priceQuery = priceQuery.Where(r => r.Hotel_Price <= maxPrice);
                }

                return priceQuery.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while filtering the price range.", ex);
            }
        }
        //Check room availability
        public int GetAvailableRoomCount(int hotel_Id)
        {
            try
            {
                return _CustomerContext.Rooms.Count(r => r.Hotels.Hotel_Id == hotel_Id && r.Room_Status == "available");
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the count of available rooms.", ex);
            }
        }
    }
}