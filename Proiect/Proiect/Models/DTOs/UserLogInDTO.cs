using System.ComponentModel.DataAnnotations;

namespace Proiect.Models.DTOs
{
    public class UserLogInDTO
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required] 
        public string Password { get; set; } = string.Empty;
    }
}
