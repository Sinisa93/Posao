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
    
    public partial class ESM_UI_CUSTOM_TEXT
    {
        public int ROW_ID { get; set; }
        public int CUSTOM_TEXT_ID { get; set; }
        public Nullable<int> USER_GROUP_ID { get; set; }
        public Nullable<int> COMPANY_ID { get; set; }
        public Nullable<int> PROJECT_ID { get; set; }
        public Nullable<int> PART_ID { get; set; }
        public string TEXT_VALUE { get; set; }
    
        public virtual ESM_COMPANY ESM_COMPANY { get; set; }
        public virtual ESM_PART ESM_PART { get; set; }
    }
}
