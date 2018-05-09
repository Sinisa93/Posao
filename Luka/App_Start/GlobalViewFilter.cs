using System.Collections.Generic;
using System.Web.Mvc;
using Argosy.Web.FrontEnd.Models;

namespace Luka {
    public class GlobalViewFilter : ActionFilterAttribute {
        public override void OnResultExecuting(ResultExecutingContext filterContext) {
            filterContext.Controller.ViewBag.ActionLinks = new List<NavigationAction>();
            filterContext.Controller.ViewBag.Navigation = new List<NavigationAction>();

            filterContext.Controller.ViewBag.Navigation.Add(new NavigationAction() {
                                                                                       Name = "",
                                                                                       InnerClass = "fa fa-home",
                                                                                       JavaScript = "gotoHomeUrl()"

            });
        }

    }
}