using System.Web.Mvc;
using Argosy.BusinessLogic.FrontEnd.Managers;
//using Argosy.BusinessLogic.FrontEnd.Managers;
using Argosy.BusinessLogic.FrontEnd.Security;
//using Argosy.BusinessLogic.V5;
using Argosy.Web.FrontEnd.Core;
using Argosy.Web.FrontEnd.Core.Filters;
using ArgosyModel;
//using static Argosy.BusinessLogic.FrontEnd.Managers.ThemeManager;
//using CompanyManager = Argosy.BusinessLogic.FrontEnd.Managers.CompanyManager;
using System.Collections.Generic;
using static Argosy.BusinessLogic.FrontEnd.Managers.ThemeManager;
using Argosy.Web.FrontEnd.Models;
using Cerqa.Common.V5;
using System;

namespace Luka.Areas.Admin
{
    public class ThemeController : BaseController
    {
        //[AdminOnly]
        public ActionResult Index(string id)
        {

            //ViewBag.Navigation = new List<NavigationAction>();
            ViewBag.ActionLinks = new List<NavigationAction>();
            //return View();
            ViewBag.Navigation = new List<NavigationAction>();
            //var viewModel = ThemeManager.GetViewModel();
            var viewModel = new ThemesViewModel();
            viewModel.CurrentThemeId = 1;
            viewModel.CurrentThemeName = "My Admin theme";
            viewModel.ThemeGroupings = new List<ThemeGrouping>();

            var lista = new List<ThemeInfo>();
            var lista2 = new List<ThemeInfo>();

            lista.Add(new ThemeInfo() { Name = "Sinisa", ThemeId = 1, PrimaryColor = "#982938", SecondaryColor = "#219423", TertiaryColor = "#09432f", IsDefault = true, IsSystem = false });
            lista.Add(new ThemeInfo() { Name = "Pera", ThemeId = 2, PrimaryColor = "#871827", SecondaryColor = "#198312", TertiaryColor = "#98312f", IsDefault = false, IsSystem = false });
            lista.Add(new ThemeInfo() { Name = "Mika", ThemeId = 3, PrimaryColor = "#769716", SecondaryColor = "#987291", TertiaryColor = "#87201f", IsDefault = false, IsSystem = false });
            lista.Add(new ThemeInfo() { Name = "Zika", ThemeId = 4, PrimaryColor = "#658695", SecondaryColor = "#876189", TertiaryColor = "#76190f", IsDefault = false, IsSystem = false });
            lista.Add(new ThemeInfo() { Name = "Laza", ThemeId = 5, PrimaryColor = "#547584", SecondaryColor = "#765978", TertiaryColor = "#65089f", IsDefault = false, IsSystem = false });
            lista.Add(new ThemeInfo() { Name = "Perke", ThemeId = 6, PrimaryColor = "#436473", SecondaryColor = "#654867", TertiaryColor = "#54978f", IsDefault = false, IsSystem = false });
            lista.Add(new ThemeInfo() { Name = "Sloba", ThemeId = 7, PrimaryColor = "#325362", SecondaryColor = "#543756", TertiaryColor = "#43867f", IsDefault = false, IsSystem = false });
            lista.Add(new ThemeInfo() { Name = "Saki", ThemeId = 8, PrimaryColor = "#214251", SecondaryColor = "#432645", TertiaryColor = "#32756f", IsDefault = false, IsSystem = false });
            lista.Add(new ThemeInfo() { Name = "Vuja", ThemeId = 9, PrimaryColor = "#193149", SecondaryColor = "#321534", TertiaryColor = "#21645f", IsDefault = false, IsSystem = false });
            lista.Add(new ThemeInfo() { Name = "Duka", ThemeId = 10, PrimaryColor = "#982938", SecondaryColor = "#219423", TertiaryColor = "#10534f", IsDefault = false, IsSystem = false });

            lista2.Add(new ThemeInfo() { Name = "Vuja", ThemeId = 9, PrimaryColor = "#193149", SecondaryColor = "#321534", TertiaryColor = "#21645f", IsDefault = false, IsSystem = true });

            viewModel.ThemeGroupings.Add(new ThemeGrouping("Standard Themes", lista));
            viewModel.ThemeGroupings.Add(new ThemeGrouping("Created Themes", lista2));


            return View(viewModel);
        }
        [HttpPost]
        //[AdminOnly]
        //public ActionResult Create(ThemeManager.Theme theme)
        public ActionResult Create()
        {

            //var response = new ThemeManager().Create(theme);
            var listaStilova = new List<ThemeStyle>();
            listaStilova.Add(new ThemeStyle() { ThemeStyleId = 333, ThemeGroupId = 1, ThemeId = 222, DisplayName = "BackgroundColor",Value= "#752d3c" });
            listaStilova.Add(new ThemeStyle() { ThemeStyleId = 334, ThemeGroupId = 1, ThemeId = 222, DisplayName = "BackgroundColor", Value = "#734d3c" });
            listaStilova.Add(new ThemeStyle() { ThemeStyleId = 335, ThemeGroupId = 1, ThemeId = 222, DisplayName = "BackgroundColor", Value = "#712d3c" });
            var response = new Theme()
            {
                CompanyId = 1,
                GroupName="Created Themes",
                DateCreated=DateTime.Now,
                Href=null,
                IsDefault=false,
                IsDeletable=true,
                IsSystem=false,
                Name="Proba",
                PrimaryColor= "#752d3c",
                SecondaryColor= "#666666",
                SiteId=35,
                StyleSheet= null,
                TertiaryColor= "#752d3c",
                ThemeStructure=null,
                ThemeStructureId=1,
                ThemeStyles=listaStilova,
                Id=475


            };
            //var lista = new List<Theme>();

            
            //lista.Add(response);
            return Json(response, JsonRequestBehavior.AllowGet);
            
            //nedovrseno
        }
        //[HttpPost]

        //public ActionResult Create()
        //{

        //    //var response = new ThemeManager().Create(theme);
        //    var t = new Theme();

        //    t.Name = "sdadas";
        //    var rez = new MethodStatus<Theme>() { };

        //    return Json(t);
        //}
        //[AdminOnly]
        //public ActionResult Update(ThemeManager.Theme theme)
        //{
        //    var response = new ThemeManager().Update(theme);
        //    return Json(response);
        //}

        //[AdminOnly]
        //public ActionResult Delete(ThemeManager.Theme theme)
        //{
        //    var response = new ThemeManager().Delete(theme);
        //    return Json(response);
        //}

        //public void UpdateThemeGroup(ThemeManager.ThemeGroup themeGroup)
        //{
        //}

        //public void UpdateCompanyTheme(int id)
        //{
        //    CompanyManager.UpdateTheme(FrontEndSession.Instance.CompanyId.GetValueOrDefault(0), id);
        //    UpdateSessionTheme(id);
        //}

        //public ActionResult UpdateSessionTheme(int id)
        //{
        //    FrontEndSession.Instance.UpdateTheme(id);
        //    return Json(Url.Action("Index", "Style", new { id, area = "" }));
        //}
    }
}
