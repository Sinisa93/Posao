using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Luka.Controllers;

namespace Luka.Controllers
{
    public class DataViewController : Controller
    {
        // GET: DataViewController
        [AllowAnonymous]
        public ActionResult GetGlobalFormProfiles()
        {
            //Query string : gridViewSelector=div%5Bdata-argosy-view%3DGlobalProfilesGridView%5D&adminGridView=false&customGlobalFormsId=0&customProfileUrl=&companyUserId=281376&shouldHideTemps=true&uuid=264a8e7f-940d-765a-cfa1-e9e5a261584c&Page=1&PageSize=50&Skip=0&Take=50&Keyword=&IsGlobalFormsProfileActive=true
            var results = JsonToObject.Convert("GetGlobalFormProfiles.json");
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult GetOrders()
        {
            //Query string: ?ShowUserOrdersOnly=true&IsIndex=true&Page=1&PageSize=50&Skip=0&Take=50&Username=&Keyword=&OrderTag=&OrderNumber=&ProofName=&StatusId=Open&OrderDateStart=&OrderDateEnd=&UserGroup=&UserId=&PartName=&SKU=&PurchaseOrderNumber=&Custom01=&Country=&State=&City=&Zip=&Phone=&_=1524217889148
            var results = JsonToObject.Convert("GetOrders.json");
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult GetAccountUnits()
        {
            var results = JsonToObject.Convert("GetAccountUnits.json");
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult GetMessages()
        {
            var results = JsonToObject.Convert("GetMessages.json");
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult GetAccountingUnitUsers()
        {
            var results = JsonToObject.Convert("GetAccountingUnitUsers.json");
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult GetusersAvailableForAccountingUnit()
        {
            var results = JsonToObject.Convert("GetusersAvailableForAccountingUnit.json");
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult GetAccountingUnitUserGroups()
        {
            var results = JsonToObject.Convert("GetAccountingUnitUserGroups.json");
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult GetUserGroupsAvailableForAccountingUnit()
        {
            var results = JsonToObject.Convert("GetUserGroupsAvailableForAccountingUnit.json");
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult GetCompanyAddresses()
        {
            //Query string:  gridViewSelector=div%5Bdata-argosy-control%3D%27CompanyAddresses%27%5D&companyId=238&active=true&uuid=e2bd7773-d4e8-f8c7-f7e3-8cbc0d85d127&Page=1&PageSize=50&Skip=0&Take=50&Keyword=
            var results = JsonToObject.Convert("GetOrders.json");
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult GetTheme()
        {
            //Query string: ?ShowUserOrdersOnly=true&IsIndex=true&Page=1&PageSize=50&Skip=0&Take=50&Username=&Keyword=&OrderTag=&OrderNumber=&ProofName=&StatusId=Open&OrderDateStart=&OrderDateEnd=&UserGroup=&UserId=&PartName=&SKU=&PurchaseOrderNumber=&Custom01=&Country=&State=&City=&Zip=&Phone=&_=1524217889148
            var results = JsonToObject.Convert("GetTheme.json");
            return Json(results, JsonRequestBehavior.AllowGet);
        }

    }
}