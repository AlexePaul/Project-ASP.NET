using Microsoft.AspNetCore.Identity;
using Proiect.Models.Base;
using Proiect.Models.DTOs;
using System.Security.Cryptography.Xml;
using Proiect.Models.Enums;

namespace Proiect.Models
{
    public class User : BaseModel
    {
        public User() { }
        public string Password { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Role role { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();


    }
}
