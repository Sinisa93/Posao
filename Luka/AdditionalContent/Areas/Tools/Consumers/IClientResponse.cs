using Argosy.Common.Contracts.Core.Enum;

namespace Argosy.Common.Contracts.Core.Interfaces {
    public interface IClientResponse<out T> {
        ClientReturnCode ReturnCode { get; set; }
        T Data { get; }
        string Message { get; set; }
        string Guid { get; set; }
    }
}