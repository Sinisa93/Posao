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
    public partial class ESM_THEME
    {
        public ESM_THEME()
        {
            //this.ESM_COMP_USERGROUP = new HashSet<ESM_COMP_USERGROUP>();
            //this.ESM_THEME_STYLE = new HashSet<ESM_THEME_STYLE>();
            //this.ESM_COMPANY = new HashSet<ESM_COMPANY>();
        }
    	// primitiveProperties
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "THEME_ID")]
        public int THEME_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "SITE_ID")]
        public Nullable<int> SITE_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "COMPANY_ID")]
        public Nullable<int> COMPANY_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "NAME")]
        public string NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "GROUP_NAME")]
        public string GROUP_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "STYLESHEET")]
        public string STYLESHEET { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "HREF")]
        public string HREF { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "PRIMARY_COLOR")]
        public string PRIMARY_COLOR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "SECONDARY_COLOR")]
        public string SECONDARY_COLOR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "TERTIARY_COLOR")]
        public string TERTIARY_COLOR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "IS_DEFAULT")]
        public bool IS_DEFAULT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "IS_SYSTEM")]
        public bool IS_SYSTEM { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "DATE_CREATED")]
        public System.DateTime DATE_CREATED { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "THEME_STRUCTURE_ID")]
        public Nullable<int> THEME_STRUCTURE_ID { get; set; }
    	// navigationProperty
    
        /// <summary>
        /// 
        /// </summary>
        //public virtual ICollection<ESM_COMP_USERGROUP> ESM_COMP_USERGROUP { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public virtual ESM_SITE ESM_SITE { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        public virtual ESM_THEME_STRUCTURE ESM_THEME_STRUCTURE { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        public virtual ICollection<ESM_THEME_STYLE> ESM_THEME_STYLE { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public virtual ICollection<ESM_COMPANY> ESM_COMPANY { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public virtual ESM_COMPANY ESM_COMPANY1 { get; set; }
    }
}
