using EntityLayer;
using EntityService.ViewModels;

namespace EntityService.IServices
{
    public interface ICountryService : IBaseService<CountryEntity, CountryViewModel>
    {
    }
}