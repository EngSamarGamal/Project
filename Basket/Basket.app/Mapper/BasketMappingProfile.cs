using AutoMapper;
using Basket.Application.Commands;
using Basket.Application.Responses;
using Basket.Core.Entities;

namespace Basket.Application.Mapper
{
    public class BasketMappingProfile : Profile
    {
        public BasketMappingProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartResponseDto>().ReverseMap();
            CreateMap<ShoppingCartItem, ShoppingCartItemResponseDto>().ReverseMap();
            CreateMap<UpdateBasketCommand, ShoppingCart>().ReverseMap();
        }
    }
}
