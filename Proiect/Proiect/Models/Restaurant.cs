using Proiect.Models.Base;

namespace Proiect.Models
{
    public class Restaurant : BaseModel
    {
        public string Adress { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public List<Food> Foods { get; set; } = new List<Food>();
    }
}
