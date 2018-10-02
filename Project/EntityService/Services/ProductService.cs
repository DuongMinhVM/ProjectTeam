using DataAccessLayer;
using DataAccessLayer.UnitOfWorks;
using EntityLayer;
using EntityService.IServices;
using EntityService.ViewModels;

namespace EntityService.Services
{
    public class ProductService : BaseService<ProductEntity, ProductViewModel>, IProductService
    {
        public ProductService() : base(new UnitOfWork(EfDbContext.Create()))
        {
        }
    }
}