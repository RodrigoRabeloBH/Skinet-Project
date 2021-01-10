using AutoMapper;
using Skinet.Api.Dto;
using Skinet.Model;
using Skinet.Model.Identity;

namespace Skinet.Api.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
            .ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
            .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
            .ForMember(dest => dest.Percent, opt => opt.MapFrom(src => src.TierPrice.Percent))
            .ForMember(dest => dest.TierPriceDescription, opt => opt.MapFrom(src => src.TierPrice.Description))
            .ForMember(dest => dest.TierPriceId, opt => opt.MapFrom(src => src.TierPrice.Id))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<ProductUrlResolver>())
            .ReverseMap();

            CreateMap<AppUser, UserDto>();

            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<CustomerBasketDto, CustomerBasket>().ReverseMap();
            
            CreateMap<BasketItemDto, BasketItem>().ReverseMap();
        }
    }
}