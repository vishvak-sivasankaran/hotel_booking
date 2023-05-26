
using hotel.models;

namespace hotel.Repositories
{
    public interface IHotels
    {
        public IEnumerable<Hotels> GetAllhotel();
        public Hotels GethotelById(int hotel_Id);
        public Hotels Posthotel(Hotels hotel);
        public Hotels Puthotel(int hotel_Id, Hotels hotel);
        public Hotels Deletehotel(int hotel_Id);
        


    }
}
