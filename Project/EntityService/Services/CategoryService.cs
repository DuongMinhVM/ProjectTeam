using DataAccessLayer;
using DataAccessLayer.UnitOfWorks;
using EntityLayer;
using EntityService.IServices;
using EntityService.ViewModels;

namespace EntityService.Services
{
    public class CategoryService : BaseService<CategoryEntity, CategoryViewModel>, ICategoryService
    {
        public CategoryService() : base(new UnitOfWork(EfDbContext.Create()))
        {
        }
    }
}