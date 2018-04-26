using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace Cerqa.Common.V5 {
    [Serializable]
    [DataContract]
    public class MethodStatus<T> {
        #region Public Properties
        [DataMember]
        public bool IsError { get; set; }
        [DataMember]
        public MessageSeverity MessageSeverity { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string ErrorCode { get; set; }
        [DataMember]
        public ErrorType ErrorType { get; set; }
        [DataMember]
        public int ReturnId { get; set; }
        [DataMember]
        public string ExtraDataJsonString { get; set; }
        [DataMember]
        public T Data { get; set; }

        #endregion

        #region Constructors

        public MethodStatus() {
            IsError = false;
            ErrorCode = string.Empty;
            MessageSeverity = MessageSeverity.None;
            ErrorType = ErrorType.None;
            Message = "";
        }

        #endregion

        public void HandleFrontEndError() {
            if (HttpContext.Current != null && this.IsError) {
                HttpContext.Current.Response.RedirectToRoute("Error", new { controller = "Error", errors = this.ErrorCode });
            }
        }
    }
    [Serializable]
    [DataContract]
    public class MethodStatus
    {
        #region Public Enumerator

        #endregion


        #region Public Properties
        [DataMember]
        public bool IsError { get; set; }
        [DataMember]
        public MessageSeverity MessageSeverity { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string ErrorCode { get; set; }
        [DataMember]
        public ErrorType ErrorType { get; set; }
        [DataMember]
        public int ReturnId { get; set; }
        [DataMember]
        public string ExtraDataJsonString { get; set; }

        #endregion

        #region Constructors

        public MethodStatus()
        {
            IsError = false;
            ErrorCode = string.Empty;
            MessageSeverity = MessageSeverity.None;
            ErrorType = ErrorType.None;
            Message = "";
        }

        #endregion

        public void HandleFrontEndError() {
            if (HttpContext.Current != null && this.IsError) {
                HttpContext.Current.Response.RedirectToRoute("Error", new { controller = "Error", errors = this.ErrorCode });
            }
        }
        /// <summary>
        /// Creates new method status instance and initailizes to non-Error status
        /// </summary>
        /// <param name="theMethodStatus"></param>
        public static void Initialize(out MethodStatus theMethodStatus)
        {
            theMethodStatus = new MethodStatus();
            theMethodStatus.IsError = false;
            theMethodStatus.MessageSeverity = MessageSeverity.None;
            theMethodStatus.ErrorCode = string.Empty;
            theMethodStatus.ErrorType = ErrorType.None;
        }
    }
}
