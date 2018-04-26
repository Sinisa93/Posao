using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Argosy.BusinessLogic.FrontEnd.Security;

namespace Argosy.Web.FrontEnd.Core.Filters
{
    public class AdminOnlyAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }

            return FrontEndSession.Instance.IsAdmin;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Controller.TempData["errors"] = "You don't have rights to do this action.";
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new
                    {
                        area ="",
                        controller = "Error",
                        action ="Index"
                    })
            );
        }
    }

}