using System.ComponentModel.DataAnnotations;

namespace hotel.models
{
    public class HotelCustomers
    {
        [Key]
        public int Cus_id { get; set; }
        public string? Cus_name { get; set;}
        public int Cus_phone { get; set; }
        public Hotels? Hotels { get; set; }
    }
}
