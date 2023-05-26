using hotel.models;
using Microsoft.EntityFrameworkCore;

namespace hotel.Repositories
{
    public class HotelRoomsRepositories : IHotelRooms
    {
        private readonly HotelContext _RoomContext;
        public HotelRoomsRepositories(HotelContext context)
        {
            _RoomContext = context;
        }
        //GetAllRoom
        public IEnumerable<HotelRooms> GetAllRoom()
        {
            return _RoomContext.Rooms.ToList();
        }
        //GetRoomById
        public HotelRooms GetRoomById(int Room_Id)
        {
            return _RoomContext.Rooms.FirstOrDefault(x => x.Room_Id == Room_Id);
        }
        //PostRoom
        public HotelRooms PostRoom(HotelRooms Room)
        {
            var st = _RoomContext.Hotels.Find(Room.Hotels.Hotel_Id);
            Room.Hotels = st;
            _RoomContext.Add(Room);
            _RoomContext.SaveChanges();
            return Room;
        }
        //PutRoom
        public HotelRooms PutRoom(int Room_Id, HotelRooms Room)
        {
            var st = _RoomContext.Hotels.Find(Room.Hotels.Hotel_Id);
            Room.Hotels = st;
            _RoomContext.Entry(Room).State = EntityState.Modified;
            _RoomContext.SaveChangesAsync();
            return Room;
        }
        //DeletRoom
        public HotelRooms DeleteRoom(int Room_Id)
        {
            var st = _RoomContext.Rooms.Find(Room_Id);
            _RoomContext.Rooms.Remove(st);
            _RoomContext.SaveChanges();
            return st;
        }
    }
}