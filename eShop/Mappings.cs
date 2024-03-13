using AutoMapper;
using Entities.Models;
using SharedAPI.Data_Transfer;

namespace eShop
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Store, StoresDto>().ForMember(x => x.FullAddress, 
                opt => opt.MapFrom(x => 
                String.Join(", ", x.Address, x.Country)));

            CreateMap<CreateStoreDto, Store>();

            CreateMap<StoreUpdateDto, Store>();

            CreateMap<Product, OrderProducsDto>().ReverseMap();

            CreateMap<Product, ProductModifyingDto>().ReverseMap();

            CreateMap<CreateUserDto, User>();

            CreateMap<Category, CategoryDto>();

            CreateMap<CreateCategoryDto, Category>();
        }
    }
}
