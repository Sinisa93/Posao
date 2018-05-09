using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Argosy.Common.Contracts.Core.Enum {
    [DataContract]
    public class ReturnResponse {
        [DataMember]
        public string PostJsonData { get; set; }
        [DataMember]
        public string ReturnUrl { get; set; }
    }
}