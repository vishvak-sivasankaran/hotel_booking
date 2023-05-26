using System.ComponentModel.DataAnnotations;

namespace hotel.models
{
    public class Hotels
    {
        [Key]
        public int Hotel_Id { get; set; }
        public string? Hotel_Name { get; set;}
        public string? Hotel_amenities { get; set;}
        public string? Hotel_Location { get; set;}
        public int Hotel_Price { get; set; }
        public ICollection<HotelRooms>? Hotel_Rooms { get; set; }
        public ICollection<HotelStaffs>? Hotel_Staffs { get; set; }
        public ICollection<HotelCustomers>? Hotel_Customers { get; set; }

    }
}
