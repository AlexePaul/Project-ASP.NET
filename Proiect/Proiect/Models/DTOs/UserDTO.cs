using Proiect.Models.Base;
using Proiect.Models.DTOs;

namespace Proiect.Models.DTOs
{
    public class UserDTO : BaseModel
    {
        public UserDTO() { }
        public string Adress { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

    }
}
