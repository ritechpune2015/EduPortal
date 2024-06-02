using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace web.CustFilter
{
    public class UserAuth : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("UserID") == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "SignIn", controller = "ManageUsers", area = "" }));
            }
        }
    }
}
