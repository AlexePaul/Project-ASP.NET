using Proiect.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Proiect.Models.DTOs
{
    public class UserRequestDTO
    {
        public string Adress { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
