using FoodOrder.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderData
{
    public class FoodOrderContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public FoodOrderContext(DbContextOptions options) : base(options)
        {
        }
    }
}
