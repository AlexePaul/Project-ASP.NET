using Proiect.Models.Enums;

namespace Proiect.Models.DTOs
{
    public class UserOrderDTO
    {
        public string Password { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Role role { get; set; }
        public DateTime BirthDate { get; set; }
        public List<OrderUserDTO> Orders { get; set; } = new List<OrderUserDTO>();
    }
}
