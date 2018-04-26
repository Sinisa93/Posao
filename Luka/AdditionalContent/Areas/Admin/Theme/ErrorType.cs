using System;
using System.Runtime.Serialization;

namespace Cerqa.Common.V5 {
    [Serializable]
    [DataContract]
    public enum ErrorType {
        [EnumMember]
        None = 0,

        [EnumMember]
        DuplicateRecord = 1,

        [EnumMember]
        DoesNotExist = 2,

        [EnumMember]
        Unhandled = 3,

        [EnumMember]
        InvalidData = 4
    }
}