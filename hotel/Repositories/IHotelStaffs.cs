using hotel.models;

namespace hotel.Repositories
{
    public interface IHotelStaffs
    {
        public IEnumerable<HotelStaffs> GetAllStaff();
        public HotelStaffs GetStaffById(int Staff_Id);
        public HotelStaffs PostStaff(HotelStaffs staff);
        public HotelStaffs PutStaff(int Staff_Id, HotelStaffs staff);
        public HotelStaffs DeleteStaff(int Staff_Id);
    }
}
