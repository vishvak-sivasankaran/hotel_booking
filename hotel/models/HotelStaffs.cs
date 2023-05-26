using System.ComponentModel.DataAnnotations;

namespace hotel.models
{
    public class HotelStaffs
    {
        [Key]
        public int Staff_Id { get; set; }
        public string? Staff_Name { get; set; }
        public Hotels? Hotels { get; set; }

    }
}
