using System;
using System.Collections.Generic;
using System.Linq;
using FoodOrder.Model;

namespace FoodOrderData
{
    public class FoodOrderInitializer
    {
        private static FoodOrderContext _context;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            _context = (FoodOrderContext)serviceProvider.GetService(typeof(FoodOrderContext));
            InitializeData();
        }

        private static void InitializeData()
        {
            InitializeCategory();
            InitializeFood();
            InitializeCustomer();
        }

        private static void InitializeCategory()
        {
            if (_context.Categories.Any()) return;
            var categories = new List<Category>
            {
                new Category { Name = "Soup" },
                new Category { Name = "Deep Fried" },
                new Category { Name = "Beef" },
                new Category { Name = "Rice" },
                new Category { Name = "Seafood" },
                new Category { Name = "Drinks" },
                new Category { Name = "Desserts" }
            };
            _context.Categories.AddRange(categories);
            _context.SaveChanges();
        }

        private static void InitializeFood()
        {
            if (_context.Foods.Any()) return;
            var foods = new List<Food>()
            {              
                new Food() { Name = "Chicken Soup", CategoryId = 1 },
                new Food() { Name = "Seafood Soup", CategoryId = 1 },
                new Food() { Name = "Spring Roll", CategoryId = 2 },
                new Food() { Name = "Spicy Chicken Wings", CategoryId = 2 },
                new Food() { Name = "Spicy Beef", CategoryId = 3 },
                new Food() { Name = "Beef with Broccoli", CategoryId = 3 },
                new Food() { Name = "Steam Rice", CategoryId = 4 },
                new Food() { Name = "Vegetable Fried Rice", CategoryId = 4 },
                new Food() { Name = "Chicken Fried Rice", CategoryId = 4 },
                new Food() { Name = "Spicy Squids", CategoryId = 5 },
                new Food() { Name = "Spicy Shrimps", CategoryId = 5 },
                new Food() { Name = "Coffee", CategoryId = 6 },
                new Food() { Name = "Tea", CategoryId = 6 },
                new Food() { Name = "Water", CategoryId = 6 },
                new Food() { Name = "Cake", CategoryId = 7 },
                new Food() { Name = "ice cream", CategoryId = 7 }                    
            };
            _context.Foods.AddRange(foods);
            _context.SaveChanges();
        }

        private static void InitializeCustomer()
        {
            if (_context.Customers.Any()) return;
            var customers = new List<Customer>
            {
                new Customer { FirstName = "John", LastName = "Douglas" },
                new Customer { FirstName = "Rick", LastName = "Robshaw" }
            };
            _context.SaveChanges();
        }
    }
}
