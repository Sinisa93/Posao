//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Argosy.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class ESM_PAYMENT_AUTH
    {
        public int PAYMENT_AUTH_ID { get; set; }
        public Nullable<int> ORDER_ID { get; set; }
        public Nullable<int> PAYMENT_METHOD_ID { get; set; }
        public Nullable<int> CREDIT_CARD_TYPE_ID { get; set; }
        public Nullable<int> SITE_ID { get; set; }
        public string AUTHORIZATION_PNREF { get; set; }
        public decimal ORIGINAL_ORDER_TOTAL_PRICE { get; set; }
        public string CREDIT_CARD_ENDING_DIGITS { get; set; }
        public string STATUS { get; set; }
        public System.DateTime DATE_CREATED { get; set; }
        public int CREATED_BY { get; set; }
        public System.DateTime DATE_MODIFIED { get; set; }
        public int MODIFIED_BY { get; set; }
        public string ERROR_MESSAGE { get; set; }
        public string EXCETPION_DETAILS { get; set; }
        public string SPREEDLY_CARD_TOKEN { get; set; }
        public string SPREEDLY_XML_RESPONSE { get; set; }
        public Nullable<int> COMP_USER_PAYMENT_METHOD_ID { get; set; }
        public Nullable<int> BUCKET_ID { get; set; }
    
        public virtual ESM_SITE ESM_SITE { get; set; }
    }
}
