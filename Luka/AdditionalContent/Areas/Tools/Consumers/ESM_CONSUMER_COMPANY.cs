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
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    
    [DataContract]
    [Serializable]
    public partial class ESM_CONSUMER_COMPANY
    {
        public ESM_CONSUMER_COMPANY()
        {
            this.ESM_CONSUMER = new HashSet<ESM_CONSUMER>();
        }
    	// primitiveProperties
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_COMPANY_ID")]
        public int CONSUMER_COMPANY_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "COMPANY_ID")]
        public int COMPANY_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "SITE_ID")]
        public int SITE_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_COMPANY_NAME")]
        public string CONSUMER_COMPANY_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "COMP_USER_ID")]
        public Nullable<int> COMP_USER_ID { get; set; }
    	// navigationProperty
    
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<ESM_CONSUMER> ESM_CONSUMER { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ESM_SITE ESM_SITE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ESM_COMPANY ESM_COMPANY { get; set; }
    }
}
