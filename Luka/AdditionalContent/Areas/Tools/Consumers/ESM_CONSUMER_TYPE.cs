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
    public partial class ESM_CONSUMER_TYPE
    {
        public ESM_CONSUMER_TYPE()
        {
            this.ESM_CONSUMER = new HashSet<ESM_CONSUMER>();
        }
    	// primitiveProperties
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_TYPE_ID")]
        public int CONSUMER_TYPE_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "CONSUMER_TYPE_DESC")]
        public string CONSUMER_TYPE_DESC { get; set; }
    	// navigationProperty
    
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<ESM_CONSUMER> ESM_CONSUMER { get; set; }
    }
}