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
    
    public partial class ESM_GATEWAY_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESM_GATEWAY_TYPE()
        {
            this.ESM_SITE_GATEWAY = new HashSet<ESM_SITE_GATEWAY>();
        }
    
        public int GATEWAY_TYPE_ID { get; set; }
        public string NAME { get; set; }
        public System.DateTime DATE_CREATED { get; set; }
        public System.DateTime DATE_UPDATED { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESM_SITE_GATEWAY> ESM_SITE_GATEWAY { get; set; }
    }
}
