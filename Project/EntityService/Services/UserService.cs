using AutoMapper;
using DataAccessLayer;
using EntityLayer;
using EntityService.IServices;
using EntityService.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EntityService.Services
{
    public class UserService : IUserService
    {
        private readonly UserStore<UserEntity> _userStore;
        private readonly UserManager<UserEntity> _userManager;
        private readonly string _secret = "XCAP05H6LoKvbRRa/QkqLNMI7cOHguaRyHzyg7n5qEkGjQmtBhz4SzYh4Fqwjyi3KJHlSXKPwVu2+bXr6CtpgQ==";

        public UserService()
        {
            _userStore = new UserStore<UserEntity>(new EfDbContext());
            _userManager = new UserManager<UserEntity>(_userStore);
        }

        public async Task<IdentityResult> RegisterAccountUser(UserViewModel userViewModel)
        {
            UserEntity mapper = Mapper.Map<UserEntity>(userViewModel);

            _userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6
            };
            IdentityResult result = await _userManager.CreateAsync(mapper, mapper.Password);
            return result;
        }

        public async Task<string> LoginUser(UserViewModel userViewModel)
        {
            UserEntity userEntity = Mapper.Map<UserEntity>(userViewModel);
            UserEntity user = await _userManager.FindAsync(userEntity.UserName, userEntity.Password);
            return user != null ? GetToken(userViewModel.UserName) : null;
        }

        private string GetToken(string UserName)
        {
            byte[] key = Convert.FromBase64String(_secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                      new Claim(ClaimTypes.Name, UserName)}),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}