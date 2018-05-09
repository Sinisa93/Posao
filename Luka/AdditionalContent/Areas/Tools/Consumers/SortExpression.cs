using System;
using System.Runtime.Serialization;

namespace Argosy.BusinessLogic.Services.Public.Entities {
    [DataContract]
    [Serializable]
    public class SortExpression {
        public SortExpression() {
            
        }

        public SortExpression(string field, string direction) {
            this.field = field;
            this.dir = direction;
        }
        [DataMember]
        public string field { get; set; }

        [DataMember]
        public string dir { get; set; }
    }
}