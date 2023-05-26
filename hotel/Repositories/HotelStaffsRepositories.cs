using hotel.models;
using Microsoft.EntityFrameworkCore;

namespace hotel.Repositories
{
    public class HotelStaffRepositories : IHotelStaffs
    {
        private readonly HotelContext _StaffContext;
        public HotelStaffRepositories(HotelContext context)
        {
            _StaffContext = context;
        }
        //GetAllStaff
        public IEnumerable<HotelStaffs> GetAllStaff()
        {
            return _StaffContext.Staffs.ToList();
        }
        //GetStaffById
        public HotelStaffs GetStaffById(int Staff_Id)
        {
            return _StaffContext.Staffs.FirstOrDefault(x => x.Staff_Id == Staff_Id);
        }
        //PostStaff
        public HotelStaffs PostStaff(HotelStaffs staff)
        {
            var st = _StaffContext.Hotels.Find(staff.Hotels.Hotel_Id);
            staff.Hotels = st;
            _StaffContext.Add(staff);
            _StaffContext.SaveChanges();
            return staff;
        }
        //PutStaff
        public HotelStaffs PutStaff(int Staff_Id, HotelStaffs staff)
        {
            var st = _StaffContext.Hotels.Find(staff.Hotels.Hotel_Id);
            staff.Hotels = st;
            _StaffContext.Entry(staff).State = EntityState.Modified;
            _StaffContext.SaveChangesAsync();
            return staff;
        }
        //Deletstaff
        public HotelStaffs DeleteStaff(int Staff_Id)
        {
            var st = _StaffContext.Staffs.Find(Staff_Id);
            _StaffContext.Staffs.Remove(st);
            _StaffContext.SaveChanges();
            return st;
        }
    }
}