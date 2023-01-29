namespace Proiect.Models.DTOs
{
    public class FoodRequestDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; } // this is the actual ammount of food (E.g. 600 grams)
        public int Price { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
