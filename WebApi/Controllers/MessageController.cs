using System;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class MessageController : ControllerBase
    {
        // GET
        public ActionResult<String> Index()
        {
            return "";
        }
    }
}