namespace FoodOrder.API.Resources
{
    public class FoodResource
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public KeyValuePairResource Category { get; set; }
        public bool IsActive { get; set; }
    }
}
