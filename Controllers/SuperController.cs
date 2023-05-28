using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Library.Controllers
{
    public class SuperController : Controller
    {
        //設置登入限制，若須借書須先登入帳號
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (!HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USER))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Controller = "Home",
                    Action = "Login",
                }));

            }
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
