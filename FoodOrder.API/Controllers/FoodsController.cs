using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.API.Resources;
using FoodOrder.Model;
using FoodOrderData.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.API.Controllers
{
    [Route("/api/foods")]
    public class FoodsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;

        public FoodsController(IUnitOfWork unitOfWork, IFoodRepository foodRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _foodRepository = foodRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFood(int id)
        {
            var food = await _foodRepository.GetFood(id);
            if (food == null) return NotFound();
            var foodResource = _mapper.Map<Food, FoodResource>(food);
            
            return Ok(foodResource);
        }

        [HttpGet]
        public async Task<IActionResult> GetFoods(FoodQueryResource filterResource)
        {
            var filter = _mapper.Map<FoodQueryResource, FoodQuery>(filterResource);
            var foods = await _foodRepository.GetFoods(filter);
            
            return Ok(_mapper.Map<QueryResult<Food>, QueryResultResource<FoodResource>>(foods));
        }
    }
}
