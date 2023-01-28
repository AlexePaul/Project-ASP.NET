using Proiect.Models.Base;

namespace Proiect.Models
{
    public class Food : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; } // this is the actual ammount of food (E.g. 600 grams)

        public int Price { get; set; }

        public string Category { get; set; } = string.Empty;

        public Restaurant Restaurant { get; set; }
        public Guid RestaurantId { get; set; }
        public List<OrderContains> orders {get; set; } = new List<OrderContains>();
    }
}
