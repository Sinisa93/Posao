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
    
    public partial class ESM_COMPANY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESM_COMPANY()
        {
            this.ESM_COMP_USERGROUP = new HashSet<ESM_COMP_USERGROUP>();
            this.ESM_COMP_USERS = new HashSet<ESM_COMP_USERS>();
            this.ESM_ORDERS = new HashSet<ESM_ORDERS>();
            this.ESM_PART = new HashSet<ESM_PART>();
            this.ESM_UI_CUSTOM_TEXT = new HashSet<ESM_UI_CUSTOM_TEXT>();
        }
    
        public int COMPANY_ID { get; set; }
        public Nullable<int> COMP_CONTACT_ID { get; set; }
        public Nullable<int> PARTNER_ID { get; set; }
        public Nullable<int> IMAGE_ID { get; set; }
        public Nullable<int> THEME_ID { get; set; }
        public int SITE_ID { get; set; }
        public int DEFAULT_USER_ID { get; set; }
        public Nullable<int> WAREHOUSE_ID { get; set; }
        public string COMPANY_NAME { get; set; }
        public Nullable<int> STORE_USER_ID { get; set; }
        public Nullable<int> DEFAULT_SKIN_ID { get; set; }
        public string STORE_GUID { get; set; }
        public string COMPANY_URL { get; set; }
        public string CUSTOM_LOGINPATH { get; set; }
        public string CUSTOM_PACKLIST_PATH { get; set; }
        public string REPORT_CODE { get; set; }
        public string FILENAME { get; set; }
        public int LEAD_TIME { get; set; }
        public int CUSTOM_COUNT { get; set; }
        public decimal PREPRESS_CHARGE { get; set; }
        public decimal ORDER_CHARGE { get; set; }
        public decimal LINE_CHARGE { get; set; }
        public decimal EACH_CHARGE { get; set; }
        public decimal MAX_ORDER_AMOUNT { get; set; }
        public decimal MIN_ORDER_AMT { get; set; }
        public decimal EDELIVERY_PRICE { get; set; }
        public string ECOMMERCE_ACCESS_CODE { get; set; }
        public string LANDING_PAGE_HTML { get; set; }
        public string LANDING_PAGE_SETTING { get; set; }
        public string FTP_SITE { get; set; }
        public string FTP_USERNAME { get; set; }
        public string FTP_PASSWORD { get; set; }
        public long USER_DEFAULT_PART_IMAGE_MAX { get; set; }
        public long USER_DEFAULT_PART_IMAGE_MIN { get; set; }
        public string CYCLE { get; set; }
        public string ORDER_NUMBER_SUFIX { get; set; }
        public Nullable<int> ORDER_MID_NUM { get; set; }
        public string ORDER_NUMBER_PREFIX { get; set; }
        public string TIME_EXPEDITE { get; set; }
        public string TIME_CUTOFF { get; set; }
        public int VERSION { get; set; }
        public bool PAYMENT_CREDIT_CARD_IS_ALLOWED { get; set; }
        public bool PAYMENT_ECHECK_IS_ALLOWED { get; set; }
        public bool PAYMENT_PO_IS_ALLOWED { get; set; }
        public bool PAYMENT_BILL_LATER_IS_ALLOWED { get; set; }
        public decimal DIRECT_MAIL_SPENDING_MINIMUM { get; set; }
        public bool ISACTIVE { get; set; }
        public bool IS_TAXABLE { get; set; }
        public bool IS_FREIGHT_ONLY_BILLING { get; set; }
        public bool IS_ECOMMERCE_CODE_REQUIRED { get; set; }
        public bool ALLOW_PART_RESTRICTION { get; set; }
        public bool FLAG_REQUIRE_PO { get; set; }
        public string FLAG_APPROVALS { get; set; }
        public string FLAG_SPENDING_LIMITS { get; set; }
        public string FLAG_ADDRESS_EDIT_ST { get; set; }
        public string FLAG_SHOW_PRICE { get; set; }
        public string FLAG_SHOW_INV { get; set; }
        public string FLAG_PARTIAL_SHIP { get; set; }
        public string FLAG_ORDER_UNITS { get; set; }
        public string FLAG_ORDER_QTY_MAX { get; set; }
        public string FLAG_EMAIL_HTML { get; set; }
        public string FLAG_GEN_XML { get; set; }
        public string FLAG_INCLUDE_CUSTOM_FIELDS { get; set; }
        public bool FLAG_VERIFY_ADDRESS { get; set; }
        public string FLAG_AUTO_DEPLETE { get; set; }
        public string FLAG_COLAB_TOOL { get; set; }
        public string FLAG_CUSTOMIZE { get; set; }
        public string FLAG_CARRIER { get; set; }
        public string FLAG_ORDER_STATUS { get; set; }
        public string FLAG_SHIPPING_COSTS { get; set; }
        public string FLAG_DESIRED_SHIP_DATE { get; set; }
        public string FLAG_ESTIMATE_SHIP_DATE { get; set; }
        public string FLAG_BROWSE_DISPLAY { get; set; }
        public string FLAG_CC_REQUIRED { get; set; }
        public string FLAG_USE_PRECLOSE { get; set; }
        public string FLAG_CC_PROCESS { get; set; }
        public string FLAG_SHOW_PART_THUMBS { get; set; }
        public string FLAG_ALLOW_EDIT_GROUP_TITLES { get; set; }
        public bool FLAG_ALLOW_GEOROUT { get; set; }
        public string FLAG_SHOW_NEW_PRODUCTS_GROUP { get; set; }
        public string FLAG_FREE_CF_PARTS { get; set; }
        public string FLAG_FAST_PICKPACK { get; set; }
        public string FLAG_FAST_PICKPACK_DEFAULT { get; set; }
        public string FLAG_ALLOW_SPLIT_SHIPPING { get; set; }
        public string FLAG_ALLOW_CONSOLIDATE_ORDERS { get; set; }
        public bool FLAG_CONSUMER_MODULE { get; set; }
        public bool FLAG_ASSET_MODULE { get; set; }
        public bool FLAG_ASSET_RESTRICTED { get; set; }
        public string FLAG_ALLOW_LIST_PURCHASES { get; set; }
        public bool FLAG_ALLOW_UPLOAD_LIST { get; set; }
        public bool FLAG_ALLOW_EXISTING_LIST { get; set; }
        public bool FLAG_ALLOW_BUILD_LIST { get; set; }
        public bool FLAG_USERS_CAN_EDIT_PERSONAL_INFORMATION { get; set; }
        public bool FLAG_NEEDS_INVENTORY_APPROVAL { get; set; }
        public bool FLAG_HAS_PART_LIMITS { get; set; }
        public bool FLAG_REQUIRE_SIGNATURE { get; set; }
        public bool FLAG_IS_SYSTEM_DOLLAR { get; set; }
        public bool FLAG_ECOMMERCE_CUSTOMER { get; set; }
        public string FLAG_SHOW_PART_CATEGORY_THUMBS { get; set; }
        public bool FLAG_SHOW_CORPORATE_LIST { get; set; }
        public bool FLAG_ALLOW_EDIT_PRICE { get; set; }
        public bool FLAG_ALLOW_MULTI_PRICE_LIST { get; set; }
        public bool FLAG_ALLOW_PARTIAL_WAVE_FOR_KITS { get; set; }
        public string FLAG_STOP_ORDERS { get; set; }
        public bool FLAG_REQUIRE_CARTONS { get; set; }
        public Nullable<bool> FLAG_USER_CAN_CHANGE_SKIN { get; set; }
        public bool FLAG_ALLOW_PROMO_CODES { get; set; }
        public bool FLAG_SHOW_CROSS_SALE { get; set; }
        public bool FLAG_APPROVAL_ON_ALL_ORDERS { get; set; }
        public bool FLAG_APPROVAL_ON_AU { get; set; }
        public bool FLAG_APPROVAL_ON_PART_THRESHHOLD { get; set; }
        public bool FLAG_APPROVAL_ON_SPENDING_LIMIT { get; set; }
        public bool FLAG_BYPASS_APPROVAL_ON_CC { get; set; }
        public string FLAG_APPROVAL_WORK_FLOW_TYPE { get; set; }
        public string FLAG_ALLOW_WEEKEND_SHIP { get; set; }
        public bool FLAG_SHOW_HIGH_RES_PROOF { get; set; }
        public string SHIPPING_DAY { get; set; }
        public string TIME_INTERVAL { get; set; }
        public string CONSUMER_VIEW_RIGHTS { get; set; }
        public Nullable<System.DateTime> DATECREATED { get; set; }
        public int CREATEDBY { get; set; }
        public Nullable<System.DateTime> DATEMODIFIED { get; set; }
        public int MODIFIEDBY { get; set; }
        public int RETAIL_SIGNATURE_NUMBER { get; set; }
        public bool IS_TEST_CUSTOMER { get; set; }
        public bool FLAG_ALLOW_REGISTRATION { get; set; }
        public int FLAG_SALES_TAX_TYPE { get; set; }
        public Nullable<decimal> FLAT_SALES_TAX_RATE { get; set; }
        public bool FLAG_CREATE_PAY_REC_FOR_ALL { get; set; }
        public System.Guid COMPANY_GUID { get; set; }
        public bool FLAG_SAVE_ACCOUNTING_UNIT_TO_ORDERLINE { get; set; }
        public bool FLAG_CXML_PUNCHOUT { get; set; }
        public string RETURN_URL { get; set; }
        public bool FLAG_LOCK_PROOF_NAME { get; set; }
        public bool FLAG_APPROVAL_OVERRIDE_PART_LIMIT { get; set; }
        public bool FLAG_APPROVAL_ON_ORDERS_PER_DAY { get; set; }
        public bool FLAG_SHOW_ALERT_IF_APPROVAL_TRIGGERED { get; set; }
        public string WHITE_LABEL { get; set; }
        public string WHITE_LABEL_SITE_LOGO { get; set; }
        public string WHITE_LABEL_LOADING_IMAGE { get; set; }
        public string WHITE_LABEL_SITE_ICON { get; set; }
        public bool FLAG_LOCK_ADDRESS { get; set; }
        public string EXTERNAL_ID_1 { get; set; }
        public string EXTERNAL_ID_2 { get; set; }
        public Nullable<int> SITE_GATEWAY_ID { get; set; }
        public bool PAYMENT_CO_OP_ONLY { get; set; }
        public Nullable<decimal> FULFILL_MIN_COST { get; set; }
        public Nullable<decimal> FULFILL_MIN_ORDER_COST { get; set; }
        public Nullable<int> ORDER_PAYMENT_TYPE { get; set; }
        public int EXPIRING_SOON_DAYS { get; set; }
        public int NEW_SHOWS_CONTROL_FIELD { get; set; }
        public int NEW_SHOWS_FOR_DAYS { get; set; }
        public int UPDATED_SHOWS_CONTROL_FIELD { get; set; }
        public int UPDATED_SHOWS_FOR_DAYS { get; set; }
        public bool FLAG_VIEW_SKU_ON_BROWSE { get; set; }
        public bool FLAG_ALWAYS_REQUIRE_SHIPPING_ADDRESS { get; set; }
        public bool FLAG_ALWAYS_REQUIRE_BILLING_ADDRESS { get; set; }
        public bool IS_APPROVAL_WORKFLOW { get; set; }
        public bool FLAG_LOCK_ADDRESS_BT { get; set; }
        public bool FLAG_ALLOW_SAVE_CC { get; set; }
        public bool SHOW_PASSWORD_ON_WELCOME_EMAIL { get; set; }
        public Nullable<decimal> INVOICE_FEE { get; set; }
        public bool FLAG_SHOW_INVOICE_FEE { get; set; }
        public bool FLAG_ALLOW_USER_MANAGEMENT { get; set; }
        public Nullable<bool> FLAG_DEFAULT_SHIPPING { get; set; }
        public Nullable<bool> FLAG_DEFAULT_BILLING { get; set; }
        public string PORTAL_DISPLAY_JSON { get; set; }
        public string TAX_ENTITY_ID { get; set; }
        public bool IS_SHIPPING_HIDDEN { get; set; }
        public bool FLAG_OPEN_PORTAL_COMPANY_NAME_REQUIRED { get; set; }
        public bool FLAG_SHOW_ADDITIONAL_PART_DETAILS { get; set; }
        public bool FLAG_ALLOW_ADDITIONAL_ORDER_FILES { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESM_COMP_USERGROUP> ESM_COMP_USERGROUP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESM_COMP_USERS> ESM_COMP_USERS { get; set; }
        public virtual ESM_SITE ESM_SITE { get; set; }
        public virtual ESM_SITE_GATEWAY ESM_SITE_GATEWAY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESM_ORDERS> ESM_ORDERS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESM_PART> ESM_PART { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESM_UI_CUSTOM_TEXT> ESM_UI_CUSTOM_TEXT { get; set; }
    }
}