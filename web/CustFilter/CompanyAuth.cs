using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace web.CustFilter
{
    public class CompanyAuth : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("CompanyID") == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "SignIn", controller = "ManageTrainingCompanies", area = "" }));
            }
        }
    }
}
