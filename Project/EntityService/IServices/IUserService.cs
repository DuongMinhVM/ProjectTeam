using EntityLayer;
using EntityService.ViewModels;

namespace EntityService.IServices
{
    public interface IUserService : IBaseService<UserEntity, UserViewModel>
    {
    }
}