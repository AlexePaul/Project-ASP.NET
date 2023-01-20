using Proiect.Models.Base;

namespace Proiect.Models
{
    public class User : BaseModel
    {
        public string Adress { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        public List<Order> Orders { get; set; }


    }
}
