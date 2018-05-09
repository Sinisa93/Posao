using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Argosy.BusinessLogic.Services.Client.Entities;
//using Argosy.BusinessLogic.Services.Public.Entities;
using Argosy.Common.Attributes;
using Cerqa.Common.V5;
using Argosy.Common.Contracts.Core.Interfaces;
using Argosy.Common.Enums;
using Argosy.BusinessLogic.Services.Public.Entities;

namespace Argosy.BusinessLogic.FrontEnd.Interfaces {
    public interface ISearchObject<TEntity> : ISearchObject {
        //IQueryable<TEntity> ToQuery(params Expression<Func<TEntity, object>>[] includeChildPropertiesExpression);
    }

    public interface ISearchObject : ISearch
    {
        List<SortExpression> SortExpressions { get; set; }
        List<FilterExpression> FilterExpressions { get; set; }
        DefaultSortAttribute GetDefaultSort { get; }
        //string BuildDefaultSortExpression();
        MethodStatus<bool> Validate();
        RecordSizeCategory RecordSizeCategory { get; set; }
    }
}
