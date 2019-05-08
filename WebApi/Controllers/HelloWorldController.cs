using Microsoft.AspNetCore.Mvc;
using WebApi.entity;
using WebApi.Filter;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        [NoPermissionRequired]
        public ActionResult<User> HelloWorld1()
        {
            var ints = new int[] {1, 2, 3};
            var i = ints[5];
            return new User()
            {
                Id = 1,
                Name = "zz"
            };
        }

        [HttpPost]
        public ActionResult<string> HelloWorld2()
        {
            return "Post: Hello World!";
        }

        [HttpDelete]
        public ActionResult<string> HelloWorld3()
        {
            return "Delete: Hello World!";
        }

        [HttpPut]
        public ActionResult<string> HelloWorld4()
        {
            return "Put: Hello World!";
        }
    }
}