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
    
    public partial class ESM_COUNTRIES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESM_COUNTRIES()
        {
            this.ESM_STATES = new HashSet<ESM_STATES>();
        }
    
        public int COUNTRY_ID { get; set; }
        public string COUNTRY { get; set; }
        public string COUNTRY_CODE { get; set; }
        public Nullable<System.DateTime> DATECREATED { get; set; }
        public Nullable<int> CREATEDBY { get; set; }
        public Nullable<System.DateTime> DATEMODIFIED { get; set; }
        public Nullable<int> MODIFIEDBY { get; set; }
        public bool IS_STATE_REQUIRED { get; set; }
        public bool IS_ZIP_REQUIRED { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESM_STATES> ESM_STATES { get; set; }
    }
}