using Proiect.Models.Base;

namespace Proiect.Models
{
    public class Restaurant : BaseModel
    {
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }

        public List<Food> Foods { get; set; }
    }
}
