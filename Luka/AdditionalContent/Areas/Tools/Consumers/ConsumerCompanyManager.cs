using System.Collections.Generic;
using System.Linq;
using Argosy.BusinessLogic.FrontEnd.Impl;
using Argosy.Common.Attributes;
using Argosy.Common.Enums;
using Argosy.Common.Interfaces;
using ArgosyModel;
//using ServiceStack.DataAnnotations;

namespace Argosy.BusinessLogic.FrontEnd.Managers
{
    //public class ConsumerCompanyManager : AbstractFrontEndManager<ConsumerCompanyManager.ConsumerCompany, ESM_CONSUMER_COMPANY, ConsumerCompanyManager.ConsumerCompanyProperty, ConsumerCompanyManager.ConsumerCompanySearch>
    public class ConsumerCompanyManager
    {
        public class ConsumerCompany : IObjectMap<ESM_CONSUMER_COMPANY>
        {
            public ConsumerCompany(){}
            [MappingProperty(typeof(ESM_CONSUMER_COMPANY), "CONSUMER_COMPANY_ID", typeof(int))]
            //[MappingDirection(MappingDirection.FromDatabase)]
            //[PrimaryKey]
            public int ConsumerCompanyId { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER_COMPANY), "COMPANY_ID", typeof(int))]
            public int CompanyId { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER_COMPANY), "SITE_ID", typeof(int))]
            public int SiteId { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER_COMPANY), "COMP_USER_ID", typeof(int?))]
            public int? UserId { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER_COMPANY), "CONSUMER_COMPANY_NAME", typeof(string))]
            public string CompanyName { get; set; }


        }
        [DefaultSort("CONSUMER_COMPANY_NAME", "ASC")]
        public class ConsumerCompanySearch : AbstractSearchObject<ESM_CONSUMER_COMPANY>
        {
            [MappingProperty(typeof(ESM_CONSUMER_COMPANY), "CONSUMER_COMPANY_ID", typeof(int))]
            //[IgnoreProperty(IgnoreWhen.EqualToZero)]
            public int ConsumerCompanyId { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER_COMPANY), "COMPANY_ID", typeof(int))]
            //[IgnoreProperty(IgnoreWhen.EqualToZero)]
            public int CompanyId { get; set; }

            [MappingProperty(typeof(ESM_CONSUMER_COMPANY), "CONSUMER_COMPANY_NAME", typeof(string))]
            //[IgnoreProperty(IgnoreWhen.NullEmptyOrWhiteSpace)]
            public string CompanyName { get; set; }
        }

        public enum ConsumerCompanyProperty
        {
        }

        //protected override List<ConsumerCompany> MapData(ConsumerCompanySearch search, IQueryable<ESM_CONSUMER_COMPANY> results)
        //{
        //    return BaseMapData(search, results);
        //}
    }
}
