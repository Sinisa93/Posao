using System.Collections.Generic;
using Argosy.Common.Enums;
using Argosy.BusinessLogic.Services.Client.Entities;
using Argosy.Common.Contracts.Contract;
using Argosy.Common.Interfaces;
using Cerqa.Common.V5;
using System.Linq;

namespace Argosy.BusinessLogic.FrontEnd.Interfaces {
    public interface IFrontEndManager<T, TEnum, TSearch> : IFrontEndManager<T, TSearch> where T : class {
        new MethodStatus<T> Create(T part, bool saveChanges);
        new MethodStatus<T> Create(T part);
        new MethodStatus<T> Read(object id);
        MethodStatus<T> Update(object id, Dictionary<TEnum, object> toUpdate);
        new MethodStatus<T> Update(T part);
        new MethodStatus<T> Delete(T part);
       // new PagedClientResponse<T> Search(TSearch search, RecordSizeCategory sizeCategory = RecordSizeCategory.All);
    }
    public interface IFrontEndManager<T, TSearch> where T : class
    {
        MethodStatus<T> Create(T part, bool saveChanges);
        MethodStatus<T> Create(T part);
        MethodStatus<T> Read(object id);
        MethodStatus<T> Update(T part);
        MethodStatus<T> Delete(T part);
        //PagedClientResponse<T> Search(TSearch search, RecordSizeCategory sizeCategory = RecordSizeCategory.All);
    }
}