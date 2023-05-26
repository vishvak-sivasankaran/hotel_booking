
using hotel.models;

namespace hotel.Repositories
{
    public interface IHotelRooms
    {
        public IEnumerable<HotelRooms> GetAllRoom();
        public HotelRooms GetRoomById(int Room_Id);
        public HotelRooms PostRoom(HotelRooms Room);
        public HotelRooms PutRoom(int Room_Id, HotelRooms Room);
        public HotelRooms DeleteRoom(int Room_Id);
    }
}
