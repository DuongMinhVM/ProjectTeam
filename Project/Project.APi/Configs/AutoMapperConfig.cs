using AutoMapper;
using EntityLayer;
using EntityService.ViewModels;

namespace Project.APi.Configs
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<CategoryEntity, CatagoryViewModel>();
                c.CreateMap<CountryEntity, CountryViewModel>();
                c.CreateMap<MerchantEntity, MerchantViewModel>();
                c.CreateMap<OrderEntity, OrderViewModel>();
                c.CreateMap<ProductEntity, ProductViewModel>();
                c.CreateMap<UserEntity, UserViewModel>();
            });
        }
    }
}