using EntityService.ViewModels;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace EntityService.IServices
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterAccountUser(UserViewModel key);

        Task<string> LoginUser(UserViewModel key);
    }
}