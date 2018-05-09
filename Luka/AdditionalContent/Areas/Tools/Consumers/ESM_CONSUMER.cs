//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArgosyModel
{
    using Argosy.DataAccess;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    
    [DataContract]
    [Serializable]
    public partial class ESM_CONSUMER
    {
        public ESM_CONSUMER()
        {
            this.ESM_ORDERS = new HashSet<ESM_ORDERS>();
        }
    	// primitiveProperties
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_ID")]
        public int CONSUMER_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_TYPE_ID")]
        public int CONSUMER_TYPE_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_COMPANY_ID")]
        public int CONSUMER_COMPANY_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_FNAME")]
        public string CONSUMER_FNAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_LNAME")]
        public string CONSUMER_LNAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_ROLE")]
        public string CONSUMER_ROLE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_OPERATION_LOCATION")]
        public string CONSUMER_OPERATION_LOCATION { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_ADDRESS1")]
        public string CONSUMER_ADDRESS1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_ADDRESS2")]
        public string CONSUMER_ADDRESS2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_ADDRESS3")]
        public string CONSUMER_ADDRESS3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_STATE")]
        public int CONSUMER_STATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_CITY")]
        public string CONSUMER_CITY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_ZIP")]
        public string CONSUMER_ZIP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_COUNTRY")]
        public string CONSUMER_COUNTRY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_PHONE")]
        public string CONSUMER_PHONE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_EMAIL")]
        public string CONSUMER_EMAIL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "IS_RESIDENTIAL_ADDRESS")]
        public bool IS_RESIDENTIAL_ADDRESS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "COMMENT")]
        public string COMMENT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CUSTOM01")]
        public string CUSTOM01 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CUSTOM02")]
        public string CUSTOM02 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CUSTOM03")]
        public string CUSTOM03 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CUSTOM04")]
        public string CUSTOM04 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CUSTOM05")]
        public string CUSTOM05 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "COMP_USER_ID")]
        public Nullable<int> COMP_USER_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "COUNTRY_ID")]
        public Nullable<int> COUNTRY_ID { get; set; }
    	// navigationProperty
    
        /// <summary>
        /// 
        /// </summary>
        //public virtual ESM_CONSUMER_COMPANY ESM_CONSUMER_COMPANY { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public virtual ESM_CONSUMER_TYPE ESM_CONSUMER_TYPE { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        public virtual ESM_STATES ESM_STATES { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public virtual ESM_COMP_USERS ESM_COMP_USERS { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public virtual ESM_COUNTRIES ESM_COUNTRIES { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<ESM_ORDERS> ESM_ORDERS { get; set; }
    }
}
