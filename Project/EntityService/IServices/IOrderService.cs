using EntityLayer;
using EntityService.ViewModels;

namespace EntityService.IServices
{
    public interface IOrderService : IBaseService<OrderEntity, OrderViewModel>
    {
    }
}