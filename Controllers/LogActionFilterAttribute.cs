
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RegisterAndLoginApp.Models;
using RegisterAndLoginApp.Services.Utility;

namespace RegisterAndLoginApp.Controllers
{
    internal class LogActionFilterAttribute : Attribute, IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            UserModel user = (UserModel)((Controller)context.Controller).ViewData.Model;
            MyLogger.GetInstance().Info("Parameter: " + user.ToString());
            MyLogger.GetInstance().Info("Leaving the Process Login Method.");
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            MyLogger.GetInstance().Info("Entering the ProcessLogin Method");
        }
    }
}