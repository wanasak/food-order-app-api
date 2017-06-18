using System.Threading.Tasks;

namespace FoodOrderData.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}