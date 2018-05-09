using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Argosy.BusinessLogic.Extensions;
using Argosy.BusinessLogic.FrontEnd.Impl;
using Argosy.BusinessLogic.FrontEnd.Security;
//using Argosy.BusinessLogic.V5;
using Argosy.Common.Attributes;
using Argosy.Common.Contracts.Contract;
using Argosy.Common.Contracts.Core.Enum;
using Argosy.Common.Enums;
using Argosy.Common.Interfaces;
using ArgosyModel;

//using Cerqa.Common.V5.ErrorHandling;


namespace Argosy.BusinessLogic.FrontEnd.Managers
{
    //public class ConsumerManager : AbstractFrontEndManager<ConsumerManager.Consumer, ESM_CONSUMER, ConsumerManager.ConsumerProperty, ConsumerManager.ConsumerSearch>
    //{
    public class ConsumerManager
    { 

        public class Consumer : IObjectMap<ESM_CONSUMER>
        {
            public Consumer(){}
            
            [MappingProperty(typeof(ESM_CONSUMER), "CONSUMER_ID", typeof(int))]
            [Required]
            //[ServiceStack.DataAnnotations.PrimaryKey]
            public int ConsumerId { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER), "ESM_CONSUMER_COMPANY.CONSUMER_COMPANY_NAME", typeof(string))]
            [DisplayName("~{Company}~")]
            //[MappingDirection(MappingDirection.FromDatabase)]
			[Required(ErrorMessage = "Company is required.")]
            public string ConsumerCompanyName { get; set; }

            [MappingProperty(typeof (ESM_CONSUMER), "CONSUMER_FNAME", typeof (string))]
            [DisplayName("~{FirstName}~")]
            [Required(ErrorMessage = "First name is required.")]
            public string ConsumerFirstName{get; set;}
            

            [MappingProperty(typeof(ESM_CONSUMER), "CONSUMER_LNAME", typeof(string))]
            [Required(ErrorMessage = "Last name is required.")]
            [DisplayName("~{LastName}~")]
            public string ConsumerLastName { get; set; }
            
            [Required(ErrorMessage = "Consumer type is required.")]
            [MappingProperty(typeof(ESM_CONSUMER), "CONSUMER_TYPE_ID", typeof(int))]
            [DisplayName("~{Type}~")]
            public int ConsumerTypeId { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER), "CONSUMER_COMPANY_ID", typeof(int))]
            [DisplayName("~{Company}~")]
            public int ConsumerCompanyId { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER), "ESM_CONSUMER_TYPE.CONSUMER_TYPE_DESC", typeof(string))]
           // [MappingDirection(MappingDirection.FromDatabase)]
            [DisplayName("~{Type}~")]
            public string ConsumerType { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER), "CONSUMER_ROLE", typeof(string))]
            [DisplayName("~{Role}~")]
            [DefaultValue("")]
            public string ConsumerRole { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER), "CONSUMER_OPERATION_LOCATION", typeof(string))]
            [DisplayName("~{OperationLocation}~")]
            [DefaultValue("")]
            public string OperationLocation { get; set; }

            [MappingProperty(typeof (ESM_CONSUMER), "CONSUMER_PHONE", typeof (string))]
            [DefaultValue("")]
            //[MappingDirection()]
            [DisplayName("~{Phone}~")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###-##-####}")]
            public string ConsumerPhone { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER), "CONSUMER_EMAIL", typeof(string))]
            [DisplayName("~{Email}~")]
            [DefaultValue("")]
            public string ConsumerEmail { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER), "IS_RESIDENTIAL_ADDRESS", typeof(bool))]
            [DisplayName("~{ResidentialAddress}~")]
            public bool IsResidentialAddress { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER), "CUSTOM01", typeof(string))]
            [DisplayName("~{Custom01}~")]
            [DefaultValue("")]
            public string Custom01 { get; set; }
            [MappingProperty(typeof(ESM_CONSUMER), "CUSTOM02", typeof(string))]
            [DisplayName("~{Custom02}~")]
            [DefaultValue("")]
            public string Custom02 { get; set; }
            [MappingProperty(typeof(ESM_CONSUMER), "CUSTOM03", typeof(string))]
            [DisplayName("~{Custom03}~")]
            [DefaultValue("")]
            public string Custom03 { get; set; }
            [MappingProperty(typeof(ESM_CONSUMER), "CUSTOM04", typeof(string))]
            [DisplayName("~{Custom04}~")]
            [DefaultValue("")]
            public string Custom04 { get; set; }
            [MappingProperty(typeof(ESM_CONSUMER), "CUSTOM05", typeof(string))]
            [DisplayName("~{Custom05}~")]
            [DefaultValue("")]
            public string Custom05 { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER), "CONSUMER_CITY", typeof(string))]
            [DisplayName("~{City}~")]
            [Required(ErrorMessage = "City is required.")]
            public string ConsumerCity { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER), "CONSUMER_STATE", typeof(int))]
            [DefaultValue("0")]
            [DisplayName("~{State}~")]
            [Required(ErrorMessage = "State is required.")]
            public int ConsumerStateId { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER), typeof(ConsumerExtensions), "GetStateCode")]
            //[MappingDirection(MappingDirection.FromDatabase)]
            public string ConsumerStateCode { get; set; }
            [MappingProperty(typeof(ESM_CONSUMER), "CONSUMER_ADDRESS1", typeof(string))]
            [DisplayName("~{Address}~")]
            [Required(ErrorMessage = "Address is required.")]
            public string ConsumerAddress1 { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER), "CONSUMER_ADDRESS2", typeof(string))]
            [DefaultValue("")]
            [DisplayName("")]
            public string ConsumerAddress2 { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER), "CONSUMER_ADDRESS3", typeof(string))]
            [DefaultValue("")]
            [DisplayName("")]
            public string ConsumerAddress3 { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER), "CONSUMER_COUNTRY", typeof(string))]
            [DefaultValue("")]
            [DisplayName("~{Country}~")]
            public string Country { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER), "CONSUMER_ZIP", typeof(string))]
            [DisplayName("~{ZipCode}~")]
            [Required(ErrorMessage = "Zip is required.")]
            public string ConsumerZip { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER), "COUNTRY_ID", typeof(int))]
            [DisplayName("~{Country}~")]
            [Required(ErrorMessage = "Country is required.")]
            public int ConsumerCountry { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER), "COMMENT", typeof(string))]
            [DefaultValue("")]
            public string ConsumerComment { get; set; }

			[MappingProperty(typeof(ESM_CONSUMER), "COMP_USER_ID", typeof(int))]
			public int? CompanyUserId { get; set; }
				

            public bool LoadedInModal { get; set; }
        }

        [DefaultSort("CONSUMER_FNAME", "ASC")]
        public class ConsumerSearch : AbstractSearchObject<ESM_CONSUMER>
        {
            [MappingProperty(typeof(ESM_CONSUMER), "CONSUMER_ID", typeof(int))]
            //[IgnoreProperty(IgnoreWhen.EqualToZero)]
            public int ConsumerId { get; set; }
            [MappingProperty(typeof(ESM_CONSUMER), "COMP_USER_ID", typeof(int?))] //equality for testing purposes
            //[Equality(EqualityType.GreaterThan)]
            public int? ConsumerUserId { get; set; }
            [MappingProperty(typeof(ESM_CONSUMER), typeof(string), "CONSUMER_FNAME", "CONSUMER_LNAME", "ESM_CONSUMER_COMPANY.CONSUMER_COMPANY_NAME")]
            //[Equality(EqualityType.Contains)]
            public string Keyword { get; set; }
        }

        //public override PagedClientResponse<Consumer> Search(ConsumerSearch search, RecordSizeCategory sizeCategory = RecordSizeCategory.All)
        //{
        //    var response = new PagedClientResponse<Consumer>();
        //    IQueryable<ESM_CONSUMER> query = null;
        //    try
        //    {
        //        int companyId = FrontEndSession.Instance.CompanyId.GetValueOrDefault(),
        //            userId = FrontEndSession.Instance.UserId.GetValueOrDefault(),
        //            userGroupId = FrontEndSession.Instance.CompanyUserGroupId;
        //        var company = new ArgosyManager<ESM_COMPANY>().GetQuery().SingleOrDefault(x => x.COMPANY_ID == companyId);
        //        char consumerViewRights;
        //        query = search.ToQuery().Where(x => x.ESM_CONSUMER_COMPANY.COMPANY_ID == companyId);
        //        if (company != null && char.TryParse(company.CONSUMER_VIEW_RIGHTS, out consumerViewRights))
        //        {
        //            switch (consumerViewRights)
        //            {
        //                case 'C':
        //                    // Always check for company
        //                    break;
        //                case 'U':
        //                    query = query.Where(x => x.COMP_USER_ID.HasValue && x.COMP_USER_ID.Value == userId);
        //                    break;
        //                case 'G':
        //                    query = query.Where(x => x.ESM_COMP_USERS != null &&
        //                                             x.ESM_COMP_USERS.ESM_COMP_USERGROUP != null &&
        //                                             x.ESM_COMP_USERS.ESM_COMP_USERGROUP.COMP_USERGROUP_ID ==
        //                                             userGroupId);
        //                    break;
        //            }
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        response.Guid = ErrorHandlingRepositoryFactory.Instance.HandleError(err,
        //            "Search for " + TypeName + " Exception", search);
        //        response.Message = "There was an error generating your " + TypeName + " query.  Please contact support.";
        //        response.ReturnCode = ClientReturnCode.Failed;
        //    }
        //    response = GeneratePagedClientResponse(search, query, sizeCategory);
        //    return response;
        //}

        public enum ConsumerProperty
        {
        }

        //protected override List<Consumer> MapData(ConsumerSearch search, IQueryable<ESM_CONSUMER> results)
        //{

        //    return base.BaseMapData(search, results);
        //}
    }
}
