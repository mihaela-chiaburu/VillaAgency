using System.Web;
using System.Web.Mvc;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Enums;

namespace eUseControl.Web.Filters
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = httpContext.Session["User"] as UserMinimal;
            if (user == null)
            {
                return false;
            }
            return user.Level.ToString() == URole.Admin.ToString();
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Login");
        }
    }
}
