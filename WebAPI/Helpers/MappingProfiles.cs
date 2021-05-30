using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Entities.OrderAggregate;
using WebAPI.DTOs;

namespace WebAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

            CreateMap<Core.Entities.Identity.Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<AddressDto, Core.Entities.OrderAggregate.Address>();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(oid => oid.DeliveryMethod, oid => oid.MapFrom(oi => oi.DeliveryMethod.ShortName))
                .ForMember(oid => oid.ShippingPrice, oid => oid.MapFrom(oi => oi.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(oid => oid.PictureUrl, oid => oid.MapFrom( oi => oi.ItemOrdered.PictureUrl))
                .ForMember(oid => oid.ProductId, oid => oid.MapFrom(oi => oi.ItemOrdered.ProductItemId))
                .ForMember(oid => oid.ProductName, oid => oid.MapFrom(oi => oi.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());

        }
    }
}
