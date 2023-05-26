using System.ComponentModel.DataAnnotations;

namespace hotel.models
{
    public class HotelRooms
    {
        [Key]
        public int Room_Id { get; set; }
        public string? Room_Type { get; set; }
        public string? Room_Status { get; set; }
        public Hotels? Hotels { get; set; }
    }
}
