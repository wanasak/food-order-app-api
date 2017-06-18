using System.Threading.Tasks;

namespace FoodOrderData.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FoodOrderContext _context;

        public UnitOfWork(FoodOrderContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
