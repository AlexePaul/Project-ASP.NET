using Proiect.Models.Base;
using Proiect.Models.DTOs;
using System.Security.Cryptography.Xml;

namespace Proiect.Models
{
    public class User : BaseModel
    {
        public User(UserRequestDTO NewUser) {
            Adress = NewUser.Adress;
            FirstName= NewUser.FirstName;
            LastName= NewUser.LastName;
            Email= NewUser.Email;
            PhoneNumber= NewUser.PhoneNumber;
            BirthDate= NewUser.BirthDate;
            }
        public User() { } 
        public string Adress { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        public List<Order> Orders { get; set; }


    }
}
