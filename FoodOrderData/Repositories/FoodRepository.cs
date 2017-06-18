using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FoodOrder.Model;
using FoodOrderData.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderData.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly FoodOrderContext _context;

        public FoodRepository(FoodOrderContext context)
        {
            _context = context;
        }

        public async Task<QueryResult<Food>> GetFoods(FoodQuery foodQuery)
        {
            var result = new QueryResult<Food>();

            var query = _context.Foods
                .Include(f => f.Category)
                .AsQueryable();

            if (foodQuery.CategoryId.HasValue)
                query = query.Where(f => f.CategoryId == foodQuery.CategoryId);

            var columnsMap = new Dictionary<string, Expression<Func<Food, object>>>()
            {
                ["name"] = f => f.Name,
                ["category"] = f => f.Category.Name
            };

            result.TotalItems = await query.CountAsync();

            query = query.ApplyOrdering(foodQuery, columnsMap);

            query = query.ApplyPaging(foodQuery);

            result.Items = await query.ToListAsync();

            return result;
        }

        public async Task<Food> GetFood(int id)
        {
            return await _context.Foods
                .Include(f => f.Category)
                .FirstOrDefaultAsync(f => f.FoodId == id);
        }

        public void Add(Food food)
        {
            _context.Foods.Add(food);
        }

        public void Remove(Food food)
        {
            _context.Foods.Remove(food);
        }
    }
}
