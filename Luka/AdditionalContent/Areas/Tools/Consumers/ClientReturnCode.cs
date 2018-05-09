using System.Runtime.Serialization;

namespace Argosy.Common.Contracts.Core.Enum
{
    [DataContract(Name = "ReturnCode")]
    public enum ClientReturnCode {
        ///<summary>
        /// 200
        ///</summary>
        [EnumMember]
        Success = 200,
        ///<summary>
        /// 500
        ///</summary>
        [EnumMember]
        Failed = 500,
    }
}