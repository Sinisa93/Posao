using System;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using Argosy.Common.Contracts.Core.Enum;
using Argosy.Common.Contracts.Core.Interfaces;
using Newtonsoft.Json;

namespace Argosy.Common.Contracts.Contract {
    [DataContract]
    public class ClientResponse<T> : IClientResponse<T> {
        public ClientResponse() {
            if (Data != null && !Data.GetType().IsPrimitive) {
                Data = (T)Activator.CreateInstance(Data.GetType());
            }
            ReturnCode = ClientReturnCode.Success;
        }

        #region Implementation of IServiceResponse<out T>
        [DataMember]
        public ClientReturnCode ReturnCode { get; set; }

        [DataMember(Name = "Records")]
        public T Data { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Guid { get; set; }

        [DataMember]
        public ReturnResponse ReturnResponse { get; set; }

        [JsonIgnore]
        [ScriptIgnore]
        public string Query { get; set; }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsValid() {
            return ReturnCode == ClientReturnCode.Success;
        }
    }
}