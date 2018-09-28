using EntityLayer;
using EntityService.ViewModels;

namespace EntityService.IServices
{
    public interface IProductService : IBaseService<ProductEntity, ProductViewModel>
    {
    }
}