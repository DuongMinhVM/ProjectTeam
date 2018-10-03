using AutoMapper;
using EntityLayer;
using EntityService.ViewModels;

namespace Project.APi.Configs
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(c =>
            {
                c.AllowNullCollections = true;
                c.CreateMap<CategoryEntity, CategoryViewModel>()
                .ForMember(dto => dto.Id, conf => conf.MapFrom(x => x.Id));
                c.CreateMap<CountryEntity, CountryViewModel>()
                .ForMember(dto => dto.Id, conf => conf.MapFrom(x => x.Id));
                c.CreateMap<MerchantEntity, MerchantViewModel>()
                .ForMember(dto => dto.Id, conf => conf.MapFrom(x => x.Id));
                c.CreateMap<OrderEntity, OrderViewModel>()
                .ForMember(dto => dto.Id, conf => conf.MapFrom(x => x.Id));
                c.CreateMap<ProductEntity, ProductViewModel>()
                .ForMember(dto => dto.Id, conf => conf.MapFrom(x => x.Id));
                c.CreateMap<UserEntity, UserViewModel>()
                .ForMember(dto => dto.Id, conf => conf.MapFrom(x => x.Id));
            });
        }
    }
}