using hotel.models;
using Microsoft.EntityFrameworkCore;

namespace hotel.Repositories
{
    public class HotelsRepositories : IHotels
    {
        private readonly HotelContext _hotelContext;
        public HotelsRepositories(HotelContext context)
        {
            _hotelContext = context;
        }
        //GetAllhotel
        public IEnumerable<Hotels> GetAllhotel()
        {
            return _hotelContext.Hotels.ToList();
        }
        //GethotelById
        public Hotels GethotelById(int hotel_Id)
        {
            return _hotelContext.Hotels.FirstOrDefault(x => x.Hotel_Id == hotel_Id);
        }
        //Posthotel
        public Hotels Posthotel(Hotels hotel)
        {
           
            _hotelContext.Add(hotel);
            _hotelContext.SaveChanges();
            return hotel;
        }
        //Puthotel
        public Hotels Puthotel(int hotel_Id, Hotels hotel)
        {
            
            _hotelContext.Entry(hotel).State = EntityState.Modified;
            _hotelContext.SaveChangesAsync();
            return hotel;
        }
        //Delethotel
        public Hotels Deletehotel(int hotel_Id)
        {
            var st = _hotelContext.Hotels.Find(hotel_Id);
            _hotelContext.Hotels.Remove(st);
            _hotelContext.SaveChanges();
            return st;
        }
         
    }
}