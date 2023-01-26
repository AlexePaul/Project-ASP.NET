using Microsoft.EntityFrameworkCore;
using Proiect.Models;

namespace Proiect.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Delivery> Deliveries { get; set; } 
        public DbSet<OrderContains> OrdersContains { get; set; }
        public DbSet<FoodReqestOrderDTO> Foods { get; set; }
        public DbSet<Restaurant> Restaurants { get; set;}
    }
}
