using System.ComponentModel.DataAnnotations;

namespace hotel.models
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        public string? User_Name { get; set; }
        public string? User_Email { get; set; }
        public string? User_Password { get; set; }
    }
}
