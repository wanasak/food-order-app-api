using System;

namespace FoodOrder.Model
{
    public class Food
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public Category Category { get; set; }
    }
}