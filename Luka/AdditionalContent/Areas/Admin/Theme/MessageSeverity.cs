using System;
using System.Runtime.Serialization;

namespace Cerqa.Common.V5 {
    [Serializable]
    [DataContract]
    public enum MessageSeverity
    {
         [EnumMember]
        None = 0,
         [EnumMember]
        Information = 1,
         [EnumMember]
        Warning = 2,
         [EnumMember]
        Error = 3
    }
}