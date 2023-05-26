using Microsoft.EntityFrameworkCore;

namespace hotel.models
{
    public class HotelContext:DbContext
    {
        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<HotelCustomers> Customers { get; set; }
        public DbSet<HotelStaffs> Staffs { get; set; }
        public DbSet<HotelRooms> Rooms { get; set; }
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

    }
}
