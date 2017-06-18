namespace FoodOrder.API.Resources
{
    public class FoodQueryResource
    {
        public int? CategoryId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
