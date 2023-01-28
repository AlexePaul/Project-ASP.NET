using Proiect.Models.Base;

namespace Proiect.Models
{
    public class OrderContains
    {
        public Order order { get; set; } 
        public Guid OrderId { get; set; }
        public Food food { get; set; }
        public Guid FoodId { get; set; }

        public int amount { get; set; } // this will specify the amount of each food type in any order.
    }
}
