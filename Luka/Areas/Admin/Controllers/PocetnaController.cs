using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Argosy.Web.FrontEnd.Models;

using Argosy.Web.FrontEnd.Core;
using Argosy.Web.FrontEnd.Core.Filters;
//using Argosy.Web.FrontEnd.Core.Filters;

namespace Luka.Areas.Admin.Controllers
{
    public class PocetnaController : Controller
    {
        // GET: Admin/Home
        
        public ActionResult Index()
        {
            ViewBag.Navigation = new List<NavigationAction>();
            return View();
        }
    }
}