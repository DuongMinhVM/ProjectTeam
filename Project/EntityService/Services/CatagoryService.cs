using DataAccessLayer;
using DataAccessLayer.UnitOfWorks;
using EntityLayer;
using EntityService.IServices;
using EntityService.ViewModels;

namespace EntityService.Services
{
    public class CatagoryService : BaseService<CatagoryEntity, CatagoryViewModel>, ICatagoryService
    {
        public CatagoryService() : base(new UnitOfWork(EFDbContext.Create()))
        {
        }
    }
}