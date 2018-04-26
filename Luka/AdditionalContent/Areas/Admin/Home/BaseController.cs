using System.Web.Mvc;
using Argosy.BusinessLogic.FrontEnd.Security;
using Argosy.BusinessLogic;
using ArgosyModel;
//using Argosy.BusinessLogic.V5;

namespace Argosy.Web.FrontEnd.Core
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (FrontEndSession.Instance.UserId.HasValue) {
                var sessionId = FrontEndSession.Instance.IsGuest ? FrontEndSession.Instance.SessionId : "";
                //FrontEndSession.Instance.CartCount = new ArgosyManager<ESM_CART>().Count(q =>q.COMP_USER_ID== FrontEndSession.Instance.UserId.Value && q.SESSION_ID == sessionId && (q.PARENT_CART_ID == null || q.PARENT_CART_ID == 0) && q.FLAG_SAVE_FOR_LATER == false);
            }
        }
    }
}
