using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLog;
using RegisterAndLoginApp.Models;
using RegisterAndLoginApp.Services;
using RegisterAndLoginApp.Services.Utility;

namespace RegisterAndLoginApp.Controllers
{
    public class LoginController : Controller
    {
        private static Logger logger = LogManager.GetLogger("LoginAppLoggerrule");
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [CustomAuthorization]
        public IActionResult PrivateSelectionMustBeLoggedIn() 
        {
            return Content("I am a protected method if the proper attribute is applied to me.");
        }


        [LogActionFilter]
        public IActionResult ProcessLogin(UserModel user)
        {
            //MyLogger.GetInstance().Info("Entering the ProcessLogin method.");
            //MyLogger.GetInstance().Info("Parameter: " + user.ToString());   

            SecurityService securityService = new SecurityService();

            if (user.UserName == "Bill Gates")
                System.Diagnostics.Debugger.Break();

            if (securityService.IsValid(user))
            {
                MyLogger.GetInstance().Info("Login success.");

                HttpContext.Session.SetString("username", user.UserName);
                //MyLogger.GetInstance().Info("Leaving the ProcessLogin method.");
                return View("LoginSuccess", user);
            }
            else 
            {
                MyLogger.GetInstance().Info("Login failure.");
                //MyLogger.GetInstance().Info("Leaving the ProcessLogin method.");
                HttpContext.Session.Remove("username");
                return View("LoginFailure", user);
            }
        }
    }
}
