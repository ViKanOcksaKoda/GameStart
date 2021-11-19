using GameStart.Core.Entities;
using GameStart.Endpoints.Products;
using AutoMapper;
using GameStart.Endpoints.Categories;

namespace GameStart
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>()
                .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Description));
        }
    }
}
