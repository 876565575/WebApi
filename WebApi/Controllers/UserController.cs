using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.entity;
using WebApi.Filter;
using WebApi.Service;

namespace WebApi.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [NoPermissionRequired]
        public ActionResult<User> Login([FromBody]User user, string content)
        {
            var loginUser = _userService.UserLogin(user);
            HttpContext.Session.SetString("userInfo", JsonConvert.SerializeObject(loginUser));
            return loginUser;
        }
    }
}