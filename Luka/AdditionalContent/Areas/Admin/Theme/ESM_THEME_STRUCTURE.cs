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
    public partial class ESM_THEME_STRUCTURE
    {
        public ESM_THEME_STRUCTURE()
        {
            this.ESM_THEME_GROUP = new HashSet<ESM_THEME_GROUP>();
            this.ESM_THEME = new HashSet<ESM_THEME>();
        }
    	// primitiveProperties
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "THEME_STRUCTURE_ID")]
        public int THEME_STRUCTURE_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "NAME")]
        public string NAME { get; set; }
    	// navigationProperty
    
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<ESM_THEME_GROUP> ESM_THEME_GROUP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<ESM_THEME> ESM_THEME { get; set; }
    }
}
