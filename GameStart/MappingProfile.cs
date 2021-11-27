using GameStart.Core.Entities;
using GameStart.Endpoints.Products;
using AutoMapper;
using GameStart.Endpoints.Categories;
using GameStart.Endpoints.Users;
using GameStart.Core.Entities.ShoppingCartAggregate;
using GameStart.Endpoints.ShoppingCartItems;

namespace GameStart
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<ShoppingCartItem, ShoppingCartItemDTO>();
        }
    }
}
