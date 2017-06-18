using AutoMapper;
using FoodOrder.API.Resources;
using FoodOrder.Model;

namespace FoodOrder.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to resource
            CreateMap<Food, FoodResource>();
            CreateMap<Category, KeyValuePairResource>()
                .ForMember(kpv => kpv.Id, opt => opt.MapFrom(c => c.CategoryId));
            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));

            // Resource to domain
            CreateMap<FoodQueryResource, FoodQuery>();
        }
    }
}
