using Proiect.Models.Base;

namespace Proiect.Models
{
    public class Food : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; } // the amount specified in this field will be in grams.

        public string Category { get; set; } = string.Empty;

        public List<OrderContains> orders {get; set; }
    }
}
