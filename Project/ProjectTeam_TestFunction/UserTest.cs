using AutoMapper;
using EntityLayer;
using EntityService.Services;
using EntityService.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTeam_TestFunction
{
    [TestClass]
    public class UserTest
    {
        private readonly UserService _userService;
        public UserTest()
        {
            _userService = new UserService();
            Mapper.Initialize(c =>
            {
                c.CreateMap<CategoryEntity, CategoryViewModel>();
                c.CreateMap<CountryEntity, CountryViewModel>();
                c.CreateMap<MerchantEntity, MerchantViewModel>();
                c.CreateMap<OrderEntity, OrderViewModel>();
                c.CreateMap<ProductEntity, ProductViewModel>();
                c.CreateMap<UserEntity, UserViewModel>();
            });
        }

        [TestMethod]
        public async Task TestLogin()
        {
            UserViewModel userViewModel = new UserViewModel
            {
                UserName = "dahkdhs1111907664",
                Password = "esajheasgeeqw"
            };
            var result = await _userService.LoginUser(userViewModel);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task TestRegister()
        {
            Random r = new Random(13);

            UserViewModel userViewModel = new UserViewModel
            {
                UserName = "dahkdhs" + r.Next().ToString(),
                Password = "esajheasgeeqw"
            };
            var result = await _userService.RegisterAccountUser(userViewModel);
            Assert.IsTrue(result.Succeeded);
        }
    }
}
