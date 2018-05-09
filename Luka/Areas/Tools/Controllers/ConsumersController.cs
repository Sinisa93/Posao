using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Argosy.BusinessLogic.FrontEnd.Managers;
using Argosy.BusinessLogic.FrontEnd.Security;
//using Argosy.BusinessLogic.Services.Client.Entities;
using Argosy.Common.Contracts.Core.Enum;
using Argosy.Web.FrontEnd.Core;
using Argosy.Web.FrontEnd.Models;
using Cerqa.Common.V5;
//using ServiceStack;
using Argosy.Common.Contracts.Contract;
using Argosy.BusinessLogic.Extensions;

namespace Luka.Areas.Tools.Controllers
{
    public class ConsumersController : Controller
    {
        private readonly ConsumerManager _consumerManager = new ConsumerManager();
        //private ConsumerManager.Consumer SearchConsumer(int consumerId)
        //{
        //    var consumer = _consumerManager.Search(new ConsumerManager.ConsumerSearch()
        //    {
        //        Skip = 0,
        //        Take = 1,
        //        ConsumerId = consumerId
        //    }).Data.FirstOrDefault();

        //    return consumer;
        //}
        // GET: Tools/ConsumerMaintenance
        public ActionResult Index()
        {
            ViewBag.ActionLinks = new List<NavigationAction>();
            ViewBag.Navigation = new List<NavigationAction>();
            return View();
        }

        public ActionResult Add()
        {
            var consumer = new ConsumerManager.Consumer();
            return View(consumer);
        }
        //[HttpGet]
        //public ActionResult Edit(int? id)
        //{
        //    ViewBag.ActionLinks = new List<NavigationAction>();
        //    ViewBag.Navigation = new List<NavigationAction>();
        //    var consumer = id == null ? new ConsumerManager.Consumer() : SearchConsumer(id.Value);
        //    return consumer == null ? View("Index") : View(consumer);
        //}

        //[HttpPost]
        //public ActionResult Edit(ConsumerManager.Consumer consumer)
        //{
        //    var updateConsumer = new MethodStatus<ConsumerManager.Consumer> { Data = consumer };
        //    if (consumer.ConsumerCompanyId <= 0)
        //    {
        //        if (!consumer.ConsumerCompanyName.IsNullOrEmpty())
        //        {
        //            var response =
        //                CreateConsumerCompany(new ConsumerCompanyModel
        //                {
        //                    CompanyName = consumer.ConsumerCompanyName.Trim()
        //                });
        //            if (!response.IsError)
        //            {
        //                consumer.ConsumerCompanyId = response.Data.ConsumerCompanyId;
        //            }
        //            else
        //            {
        //                updateConsumer.IsError = true;
        //                updateConsumer.Message = response.Message;
        //                ModelState.AddModelError("Consumer Company Name", response.Message);
        //            }
        //        }
        //        else
        //        {
        //            updateConsumer.IsError = true;
        //            updateConsumer.Message = "Could not save consumer at this time, contact administration.";
        //            ModelState.AddModelError("Consumer Company Name", "Company is required.");

        //        }
        //        if (updateConsumer.IsError)
        //        {
        //            return View(consumer);
        //        }
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        //updateConsumer = _consumerManager.Update(consumer);

        //    }
        //    return View(consumer);
        //}

        [HttpPost]
        public ActionResult Add(ConsumerManager.Consumer consumer)
        {
            ViewBag.ActionLinks = new List<NavigationAction>();
            ViewBag.Navigation = new List<NavigationAction>();
            var updateConsumer = new ClientResponse<ConsumerManager.Consumer> { Data = consumer };
            var consCompstatus = new MethodStatus<ConsumerCompanyManager.ConsumerCompany>();
            if (!consumer.ConsumerCompanyName.IsNullOrEmpty())
            {
                consCompstatus =
                    CreateConsumerCompany(new ConsumerCompanyModel
                    {
                        CompanyName = consumer.ConsumerCompanyName.Trim()
                    });
                var consComp = consCompstatus.Data;
                if (!consCompstatus.IsError)
                {
                    consumer.ConsumerCompanyId = consComp.ConsumerCompanyId;
                }
                else
                {
                    updateConsumer.ReturnCode = ClientReturnCode.Failed;
                    updateConsumer.Message = consCompstatus.Message;
                }
            }
            else
            {
                //updateConsumer.ReturnCode = ClientReturnCode.Failed;
                //updateConsumer.Message = "Company Name is required!";
            }
            if (updateConsumer.ReturnCode == ClientReturnCode.Failed)
            {
                return View(consumer);
            }

            //var status = _consumerManager.Create(consumer);
            var status = new MethodStatus<ConsumerManager.Consumer>();
            if (!status.IsError)
            {
                ViewBag.Consumer = status.Data;
                ViewBag.Result = "Consumer Added Successfully.";
                return RedirectToAction("Edit", new { id = status.Data.ConsumerId });
            }
            return View(status.Data);
        }

        //[HttpPost]
        //public JsonResult AddCompany(ConsumerCompanyModel model)
        //{
        //    return Json(CreateConsumerCompany(model));
        //}

        private MethodStatus<ConsumerCompanyManager.ConsumerCompany> CreateConsumerCompany(ConsumerCompanyModel model)
        {
            var newCompany = new MethodStatus<ConsumerCompanyManager.ConsumerCompany>
            {
                IsError = true,
                Message = "Company name already exists, please add a different name to continue."
            };
            var manager = new ConsumerCompanyManager();
            var companyId = FrontEndSession.Instance.CompanyId.GetValueOrDefault(0);
            //var foundName = manager.Search(new ConsumerCompanyManager.ConsumerCompanySearch
            //{
            //    CompanyId = companyId,
            //    CompanyName = model.CompanyName
            //});
            //if (foundName.ReturnCode != ClientReturnCode.Failed)
            //{
            //    if (foundName.TotalRecords == 0)
            //    {
            //        newCompany = manager.Update(new ConsumerCompanyManager.ConsumerCompany
            //        {
            //            SiteId = FrontEndSession.Instance.SiteId.GetValueOrDefault(0),
            //            CompanyId = companyId,
            //            CompanyName = model.CompanyName
            //        });

            //    }
            //    else
            //    {
            //        newCompany = manager.Read(foundName.Data[0].ConsumerCompanyId);
            //    }
            //    return newCompany;
            //}

            return newCompany;
        }

        [HttpPost]
        public JsonResult AddFromCheckout(ConsumerManager.Consumer consumer)
        {
            //if (ModelState.IsValid)
            //{
            //    var consCompstatus = new MethodStatus<ConsumerCompanyManager.ConsumerCompany>();
            //    if (!consumer.ConsumerCompanyName.IsNullOrEmpty())
            //    {
            //        consCompstatus =
            //            CreateConsumerCompany(new ConsumerCompanyModel
            //            {
            //                CompanyName = consumer.ConsumerCompanyName.Trim()
            //            });
            //        var consComp = consCompstatus.Data;
            //        if (!consCompstatus.IsError)
            //        {
            //            consumer.ConsumerCompanyId = consComp.ConsumerCompanyId;
            //        }
            //    }
            //    if (!consCompstatus.IsError)
            //    {
            //        var updateConsumer = _consumerManager.Create(consumer);
            //        if (!updateConsumer.IsError && !updateConsumer.Message.Contains("error"))
            //        {
            //            consumer = updateConsumer.Data;
            //        }
            //        else
            //        {
            //            updateConsumer.HandleFrontEndError();
            //        }
            //    }
            //}
            return Json(new { Consumer = consumer }, JsonRequestBehavior.AllowGet);
        }
    }
}