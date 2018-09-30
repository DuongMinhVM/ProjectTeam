using AutoMapper;
using DataAccessLayer;
using EntityLayer;
using EntityService.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace EntityService.Services
{
    public class UserService
    {
        private readonly UserStore<UserEntity> _userStore;
        private readonly UserManager<UserEntity> _userManager;
        public UserService()
        {
            _userStore = new UserStore<UserEntity>(new EfDbContext());
            _userManager = new UserManager<UserEntity>(_userStore);
        }

        public async Task<IdentityResult> RegisterAccountUser(UserViewModel userViewModel)
        {
            var mapper = Mapper.Map<UserEntity>(userViewModel);

            _userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6
            };
            var result = await _userManager.CreateAsync(mapper, mapper.Password);
            return result;
        }
    }
}
