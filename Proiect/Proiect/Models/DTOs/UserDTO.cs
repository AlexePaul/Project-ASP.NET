using Proiect.Models.Base;
using Proiect.Models.DTOs;
using Proiect.Models.Enums;

namespace Proiect.Models.DTOs
{
    public class UserDTO : BaseModel
    {
        public UserDTO() { }
        public string Adress { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Role role { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

    }
}
