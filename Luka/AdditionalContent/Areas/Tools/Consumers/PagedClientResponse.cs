using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Argosy.Common.Contracts.Contract {
    [DataContract]
    [Serializable]
    public class PagedClientResponse<T> : ClientResponse<List<T>> where T : class {
        public PagedClientResponse() {
            this.Data = new List<T>();
        }

        [DataMember]
        public int TotalRecords { get; set; }

        [DataMember]
        public int Skip { get; set; }

        [DataMember]
        public int Take { get; set; }
    }
}