using EntityService.IServices;
using EntityService.Services;
using EntityService.ViewModels;
using log4net;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.APi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly ILog _iLog = LogManager.GetLogger(nameof(UserController));

        public UserController()
        {
            _userService = new UserService();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IHttpActionResult> Login([FromBody] UserViewModel userViewModel)
        {
            try
            {
                if (userViewModel.UserName == null || userViewModel.Password == null)
                {
                    return Json(new
                    {
                        Success = false,
                        ErrorMessage = "Username and Password cann't null !"
                    });
                }
                string result = await _userService.LoginUser(userViewModel);
                if (result == null)
                {
                    return Json(new
                    {
                        Success = false,
                        ErrorMessage = "Username Or Password wrong, please login again!"
                    });
                }
                return Json(new
                {
                    Success = true,
                    Token = result
                });
            }
            catch (Exception ex)
            {
                _iLog.Error(nameof(UserController), ex);
                GC.SuppressFinalize(obj: this);
                return Json(new { Success = false, ErrorMessage = "Server Error!, Please contact administrator" });
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IHttpActionResult> Register([FromBody] UserViewModel userViewModel)
        {
            try
            {
                if (userViewModel == null)
                {
                    return Json(new
                    {
                        Success = false,
                        ErrorMessage = new ArgumentNullException(nameof(userViewModel))
                    });
                }
                if (userViewModel.UserName.Length < 8)
                {
                    return Json(new
                    {
                        Success = false,
                        ErrorMessage = $"Username must be from 8 character"
                    });
                }
                if (userViewModel.Password.Length < 8)
                {
                    return Json(new
                    {
                        Success = false,
                        ErrorMessage = $"Password must be from 8 character"
                    });
                }
                string result = await _userService.LoginUser(userViewModel);
                if (result == null)
                {
                    return Json(new
                    {
                        Success = false,
                        ErrorMessage = $"Login fail, please login again!"
                    });
                }
                else
                {
                    return Json(new
                    {
                        Success = true,
                        Token = result
                    });
                }
            }
            catch (Exception ex)
            {
                _iLog.Error(nameof(UserController), ex);
                GC.SuppressFinalize(obj: this);
                return Json(new { Success = false, ErrorMessage = "Server Error!, Please contact administrator" });
            }
        }
    }
}