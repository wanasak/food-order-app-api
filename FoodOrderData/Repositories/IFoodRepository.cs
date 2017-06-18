using System.Threading.Tasks;
using FoodOrder.Model;

namespace FoodOrderData.Repositories
{
    public interface IFoodRepository
    {
        Task<QueryResult<Food>> GetFoods(FoodQuery query);
        Task<Food> GetFood(int id);
        void Add(Food food);
        void Remove(Food food);
    }
}