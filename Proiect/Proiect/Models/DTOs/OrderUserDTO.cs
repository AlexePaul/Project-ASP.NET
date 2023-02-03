namespace Proiect.Models.DTOs
{
    public class OrderUserDTO
    {
        public string Adress { get; set; } = string.Empty;

        public UserDTO User { get; set; }
    }
}
