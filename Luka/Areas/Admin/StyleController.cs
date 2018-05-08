using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Argosy.BusinessLogic.Enums;
using Argosy.BusinessLogic.FrontEnd.Managers;
//using Argosy.BusinessLogic.FrontEnd.Managers.CustomEmails.Impl;
using Argosy.BusinessLogic.FrontEnd.Security;
//using Argosy.BusinessLogic.V5;
using Argosy.Web.FrontEnd.Models;
using ArgosyModel;
namespace Luka.Areas.Admin
{
    public class StyleController : Controller
    {
        //// GET: Style
        [HttpGet]
        [OutputCache(Duration = 3600, VaryByParam = "id")]
        [AllowAnonymous]
        public ActionResult Index(int id = 0, int siteId = 0, int companyId = 0)
        {
            //var themeManager = new ArgosyManager<ESM_THEME>();
            var listaStilova = new List<ESM_THEME>();

            var stilTema = new List<ESM_THEME_STYLE>();
            stilTema.Add(new ESM_THEME_STYLE() { DISPLAY_NAME = "Primer", IS_PRIMARY = true, IS_SECONDARY = false, IS_TERTIARY = false, NAME = "Moj primer", ROLE = "Uloga", THEME_GROUP_ID = 1, THEME_ID = 1, VALUE = "Proba", THEME_STYLE_ID = 1, SELECTOR = "", ESM_THEME = null, ESM_THEME_GROUP = null, ESM_THEME_OPTION = null });
            stilTema.Add(new ESM_THEME_STYLE() { DISPLAY_NAME = "Primer2", IS_PRIMARY = true, IS_SECONDARY = false, IS_TERTIARY = false, NAME = "Moj primer2", ROLE = "Uloga", THEME_GROUP_ID = 1, THEME_ID = 2, VALUE = "Proba1", THEME_STYLE_ID = 2, SELECTOR = "", ESM_THEME = null, ESM_THEME_GROUP = null, ESM_THEME_OPTION = null });
            stilTema.Add(new ESM_THEME_STYLE() { DISPLAY_NAME = "Primer3", IS_PRIMARY = true, IS_SECONDARY = false, IS_TERTIARY = false, NAME = "Moj primer3", ROLE = "Uloga", THEME_GROUP_ID = 1, THEME_ID = 3, VALUE = "Proba2", THEME_STYLE_ID = 3, SELECTOR = "", ESM_THEME = null, ESM_THEME_GROUP = null, ESM_THEME_OPTION = null });

            listaStilova.Add(new ESM_THEME() { COMPANY_ID = 0, DATE_CREATED = DateTime.Now, ESM_THEME_STRUCTURE = null, ESM_THEME_STYLE = stilTema, GROUP_NAME = "Theme 1", NAME = "Test1", PRIMARY_COLOR = "#ff2300", SECONDARY_COLOR = "#34ff00", TERTIARY_COLOR = "#0023ff", THEME_ID = 475, IS_DEFAULT = true, IS_SYSTEM = false, SITE_ID = 1, THEME_STRUCTURE_ID = 1, HREF = "", STYLESHEET = "" });
            listaStilova.Add(new ESM_THEME() { COMPANY_ID = 0, DATE_CREATED = DateTime.Now, ESM_THEME_STRUCTURE = null, ESM_THEME_STYLE = stilTema, GROUP_NAME = "Theme 1", NAME = "Test2", PRIMARY_COLOR = "#99ff00", SECONDARY_COLOR = "#ff0021", TERTIARY_COLOR = "#ff5500", THEME_ID = 1, IS_DEFAULT = true, IS_SYSTEM = false, SITE_ID = 1, THEME_STRUCTURE_ID = 2, HREF = "", STYLESHEET = "" });
            listaStilova.Add(new ESM_THEME() { COMPANY_ID = 0, DATE_CREATED = DateTime.Now, ESM_THEME_STRUCTURE = null, ESM_THEME_STYLE = stilTema, GROUP_NAME = "Theme 1", NAME = "Test3", PRIMARY_COLOR = "#98saff", SECONDARY_COLOR = "#00sdsdf", TERTIARY_COLOR = "#99ff00", THEME_ID = 1, IS_DEFAULT = true, IS_SYSTEM = false, SITE_ID = 1, THEME_STRUCTURE_ID = 3, HREF = "", STYLESHEET = "" });
            //IQueryable<ESM_THEME> theme;
            string styleSheet, href;

            //    if (id == 0)
            //    {
            //        if (companyId > 0)
            //        {
            //            theme = themeManager.Find(t => t.COMPANY_ID == companyId);
            //            styleSheet = theme.Select(t => t.STYLESHEET).FirstOrDefault();
            //            if (styleSheet != null) return Content(styleSheet, "text/css");
            //            href = theme.Select(t => t.HREF).FirstOrDefault();
            //            return Redirect(href);
            //        }
            //        if (siteId > 0)
            //        {
            //            theme = themeManager.Find(t => t.SITE_ID == siteId);
            //            styleSheet = theme.Select(t => t.STYLESHEET).FirstOrDefault();
            //            if (styleSheet != null) return Content(styleSheet, "text/css");
            //            href = theme.Select(t => t.HREF).FirstOrDefault();
            //            return Redirect(href);
            //        }
            //        theme = themeManager.Find(t => t.IS_DEFAULT);
            //        styleSheet = theme.Select(t => t.STYLESHEET).FirstOrDefault();
            //        if (styleSheet != null) return Content(styleSheet, "text/css");
            //        href = theme.Select(t => t.HREF).FirstOrDefault();
            //        return Redirect(href);
            //    }
            //    theme = themeManager.Find(t => t.THEME_ID == id);
            listaStilova.Select(t => t.STYLESHEET).FirstOrDefault();
            //    styleSheet = theme.Select(t => t.STYLESHEET).FirstOrDefault();
            styleSheet = listaStilova.Select(t => t.STYLESHEET).FirstOrDefault();
            string file = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Content/dodato/stil.css");
            if (styleSheet != null) return Content(styleSheet, "text/css");
            href = listaStilova.Select(t => t.HREF).FirstOrDefault();
            //    href = theme.Select(t => t.HREF).FirstOrDefault();
                return Redirect(href);
        }

            public ActionResult ChangeCss(int id = 0)
        {
            //var themeManager = new ArgosyManager<ESM_THEME>();
            var listaStilova = new List<ESM_THEME>();

            var stilTema = new List<ESM_THEME_STYLE>();
            stilTema.Add(new ESM_THEME_STYLE() { DISPLAY_NAME = "Primer", IS_PRIMARY = true, IS_SECONDARY = false, IS_TERTIARY = false, NAME = "Moj primer", ROLE = "Uloga", THEME_GROUP_ID = 1, THEME_ID = 1, VALUE = "Proba", THEME_STYLE_ID = 1, SELECTOR = "", ESM_THEME = null, ESM_THEME_GROUP = null, ESM_THEME_OPTION = null });
            stilTema.Add(new ESM_THEME_STYLE() { DISPLAY_NAME = "Primer2", IS_PRIMARY = true, IS_SECONDARY = false, IS_TERTIARY = false, NAME = "Moj primer2", ROLE = "Uloga", THEME_GROUP_ID = 1, THEME_ID = 2, VALUE = "Proba1", THEME_STYLE_ID = 2, SELECTOR = "", ESM_THEME = null, ESM_THEME_GROUP = null, ESM_THEME_OPTION = null });
            stilTema.Add(new ESM_THEME_STYLE() { DISPLAY_NAME = "Primer3", IS_PRIMARY = true, IS_SECONDARY = false, IS_TERTIARY = false, NAME = "Moj primer3", ROLE = "Uloga", THEME_GROUP_ID = 1, THEME_ID = 3, VALUE = "Proba2", THEME_STYLE_ID = 3, SELECTOR = "", ESM_THEME = null, ESM_THEME_GROUP = null, ESM_THEME_OPTION = null });

            listaStilova.Add(new ESM_THEME() { COMPANY_ID = 0, DATE_CREATED = DateTime.Now, ESM_THEME_STRUCTURE = null, ESM_THEME_STYLE = stilTema, GROUP_NAME = "Theme 1", NAME = "Test1", PRIMARY_COLOR = "#ff2300", SECONDARY_COLOR = "#34ff00", TERTIARY_COLOR = "#0023ff", THEME_ID = 475, IS_DEFAULT = true, IS_SYSTEM = false, SITE_ID = 1, THEME_STRUCTURE_ID = 1, HREF = "", STYLESHEET = "" });
            listaStilova.Add(new ESM_THEME() { COMPANY_ID = 0, DATE_CREATED = DateTime.Now, ESM_THEME_STRUCTURE = null, ESM_THEME_STYLE = stilTema, GROUP_NAME = "Theme 1", NAME = "Test2", PRIMARY_COLOR = "#99ff00", SECONDARY_COLOR = "#ff0021", TERTIARY_COLOR = "#ff5500", THEME_ID = 1, IS_DEFAULT = true, IS_SYSTEM = false, SITE_ID = 1, THEME_STRUCTURE_ID = 2, HREF = "", STYLESHEET = "" });
            listaStilova.Add(new ESM_THEME() { COMPANY_ID = 0, DATE_CREATED = DateTime.Now, ESM_THEME_STRUCTURE = null, ESM_THEME_STYLE = stilTema, GROUP_NAME = "Theme 1", NAME = "Test3", PRIMARY_COLOR = "#98saff", SECONDARY_COLOR = "#00sdsdf", TERTIARY_COLOR = "#99ff00", THEME_ID = 1, IS_DEFAULT = true, IS_SYSTEM = false, SITE_ID = 1, THEME_STRUCTURE_ID = 3, HREF = "", STYLESHEET = "" });
            // IQueryable<ESM_THEME> theme;
            string styleSheet, href;
            //theme = themeManager.Find(t => t.THEME_ID == id);
            listaStilova.Select(t => t.STYLESHEET).FirstOrDefault();
            //styleSheet = theme.Select(t => t.STYLESHEET).FirstOrDefault();
            styleSheet = listaStilova.Select(t => t.STYLESHEET).FirstOrDefault();
            string file = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Content/dodato/stil.css");
            if (styleSheet != null) return Content(file, "text/css");
            href = listaStilova.Select(t => t.HREF).FirstOrDefault();
            return Redirect(href);

        }

        //// GET: Style
        //[HttpGet]
        //[AllowAnonymous]
        //public ActionResult FavoriteIcon(int? siteId, int? companyId)
        //{
        //    if (siteId.HasValue)
        //    {
        //        FrontEndSession.Instance.FavoriteIcon = ThemeManager.GetSiteIcon(siteId.GetValueOrDefault(0), companyId.GetValueOrDefault(0), "/content/favicon.ico");
        //    }
        //    else if (string.IsNullOrWhiteSpace(FrontEndSession.Instance.FavoriteIcon))
        //    {
        //        FrontEndSession.Instance.FavoriteIcon = ThemeManager.GetSiteIcon(FrontEndSession.Instance.SiteId.GetValueOrDefault(0), FrontEndSession.Instance.CompanyId.GetValueOrDefault(0), "/content/favicon.ico");
        //    }
        //    return File(Server.MapPath(FrontEndSession.Instance.FavoriteIcon), "image/x-icon");
        //}
        //// GET: Style
        //[HttpGet]
        //[AllowAnonymous]
        //public ActionResult LoadingImage()
        //{
        //    if (string.IsNullOrWhiteSpace(FrontEndSession.Instance.LoadingImage))
        //    {
        //        FrontEndSession.Instance.LoadingImage = ThemeManager.GetLoadingImage(FrontEndSession.Instance.SiteId.GetValueOrDefault(0), FrontEndSession.Instance.CompanyId.GetValueOrDefault(0), "/content/images/loading.gif");
        //    }
        //    return File(Server.MapPath(FrontEndSession.Instance.LoadingImage), "image/gif");
        //}

        //public ActionResult GetHtmlPage(string path)
        //{
        //    return new FilePathResult(path, "text/html");
        //}

        //public ActionResult TestLandingPage()
        //{
        //    return View();
        //}
        //public ActionResult RetailProjects()
        //{
        //    return View();
        //}
        //public ActionResult RetailProfiles()
        //{
        //    return View();
        //}
        //public ActionResult RetailApprovalGroups()
        //{
        //    return View();
        //}
        //public ActionResult RetailSignPacks()
        //{
        //    return View();
        //}
        //public ActionResult RetailStores()
        //{
        //    return View();
        //}
        //public ActionResult RetailProjectDetails()
        //{
        //    return View();
        //}
        //public ActionResult RetailStoreDetails()
        //{
        //    return View();
        //}
        //public ActionResult RetailSignatureMaint()
        //{
        //    return View();
        //}
        //public ActionResult RetailProjectApproval()
        //{
        //    return View();
        //}
        //public ActionResult RetailPrintSummary()
        //{
        //    return View();
        //}
        //public ActionResult RetailProfileDetail()
        //{
        //    return View();
        //}
        //public ActionResult RetailContentSubscription()
        //{
        //    return View();
        //}

        //public ActionResult BulkOrder()
        //{
        //    return View();
        //}
        //public ActionResult RetailBulkList()
        //{
        //    return View();
        //}
        //public ActionResult Campaigns()
        //{
        //    return View();
        //}
        //public ActionResult CampaignsMaintenance()
        //{
        //    return View();
        //}
        //public ActionResult CampaignsBuilder()
        //{
        //    return View();
        //}
        //public ActionResult CampaignsContacts()
        //{
        //    return View();
        //}
        //public ActionResult CampaignsDomains()
        //{
        //    return View();
        //}
        //public ActionResult CampaignsReporting()
        //{
        //    return View();
        //}
        //public ActionResult CampaignsTemplates()
        //{
        //    return View();
        //}
        //public ActionResult CampaignsScheduler()
        //{
        //    return View();
        //}
        //public ActionResult CampaignsContactsConfigure()
        //{
        //    return View();
        //}

        //public JsonResult GetCustomEmail()
        //{
        //    var orderManager = new ArgosyManager<ESM_ORDERS>();
        //    var order = orderManager.FirstOrDefault(x => x.ORDER_ID == 2568637);
        //    var factory = new CustomEmailFactory();
        //    var orderEmailTags = factory.GetEmailTags(EmailTemplateContentType.OrderConfirmation, order);
        //    return Json(orderEmailTags.TagsAndDescription, JsonRequestBehavior.AllowGet);
        //}


        //public ActionResult TestLocalization()
        //{
        //    var model = new LocalizationMockupModel
        //    {
        //        FirstName = "Blah Blah",
        //        Description = "Should be replaced"
        //    };
        //    return View(model);
        //}
    }
}