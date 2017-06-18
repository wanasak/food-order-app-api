using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.API.Resources;
using FoodOrder.Model;
using FoodOrderData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.API.Controllers
{
    [Route("/api/categories")]
    public class CategoriesController : Controller
    {
        private readonly FoodOrderContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(FoodOrderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            var categories = await _context.Categories.AsNoTracking().ToListAsync();
            return Ok(_mapper.Map<List<Category>, List<KeyValuePairResource>>(categories));
        }
    }
}
