using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Argosy.BusinessLogic.Extensions;
using Argosy.BusinessLogic.FrontEnd.Interfaces;
using Argosy.BusinessLogic.Services.Client.Entities;
using Argosy.BusinessLogic.Services.Public.Entities;
//using Argosy.BusinessLogic.V5.Extensions;
using Argosy.Common.Attributes;
using Argosy.Common.Enums;
using Argosy.Common.Extensions;
//using Argosy.Common.Extensions;
using Argosy.Common.Interfaces;
using Cerqa.Common.V5;
//using Argosy.DataAccess;
namespace Argosy.BusinessLogic.FrontEnd.Impl
{
    [DataContract]
    public abstract class AbstractSearchObject<TEntity> : ISearchObject<TEntity> where TEntity : class
    {
        private DefaultSortAttribute _defaultSortAttribute;

        protected AbstractSearchObject()
        {
            this.SortExpressions = new List<SortExpression>();
            this.FilterExpressions = new List<FilterExpression>();
        }

        [SoapIgnore]
        [XmlIgnore]
        [DataMember]
        public string Sort
        {
            set
            {
                var sortExpressions = new List<SortExpression>();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    var sortExps = value.Split(',');
                    foreach (var sortExp in sortExps)
                    {
                        var pieces = sortExp.Split('-');
                        if (pieces.Length == 2)
                        {
                            var entityProperty = this.GetEntityPropertyName(pieces[0]);
                            if (!string.IsNullOrWhiteSpace(entityProperty))
                            {
                                sortExpressions.Add(new SortExpression(entityProperty, pieces[1].ToUpper()));
                            }
                        }
                    }
                }
                this.SortExpressions = sortExpressions;
            }
            get
            {
                return string.Join(",", this.SortExpressions.Select(s => s.field + "-" + s.dir));
            }
        }

        [SoapIgnore]
        [XmlIgnore]
        public string SortValue { get; set; }

        //public IQueryable<TEntity> ToQuery(params Expression<Func<TEntity, object>>[] includeChildPropertiesExpression)
        //{
        //    var query = this.GetSearchQuery(includeChildPropertiesExpression);
        //    if (this.FilterExpressions.Any())
        //    {
        //        query = this.FilterExpressions.Aggregate(query, this.FilterByFilterExpression);
        //    }
        //    return query;
        //}

        [SoapIgnore]
        [XmlIgnore]
        [DataMember]
        public int Skip { get; set; }

        private int _take;
        [SoapIgnore]
        [XmlIgnore]
        [DataMember]
        public int Take
        {
            get
            {
                if (_take == 0)
                {
                    _take = 1;
                }
                return _take;
            }
            set { _take = value; }
        }


        [SoapIgnore]
        [XmlIgnore]
        public List<SortExpression> SortExpressions { get; set; }

        [SoapIgnore]
        [XmlIgnore]
        public List<FilterExpression> FilterExpressions { get; set; }

        [SoapIgnore]
        [XmlIgnore]
        public DefaultSortAttribute GetDefaultSort
        {
            get
            {
                return this._defaultSortAttribute ?? (this._defaultSortAttribute = this.GetDefaultSortAttribute());
            }
        }

        //public string BuildDefaultSortExpression()
        //{
        //    string sortString = null;
        //    if (this.SortExpressions != null)
        //    {
        //        sortString = this.SortExpressions.BuildSortExpression(new SortExpression(this.GetDefaultSort.PropertyName, this.GetDefaultSort.Direction));
        //    }
        //    else
        //    {
        //        sortString = new List<SortExpression>().BuildSortExpression(new SortExpression(this.GetDefaultSort.PropertyName, this.GetDefaultSort.Direction));
        //    }
        //    return sortString;
        //}

        public MethodStatus<bool> Validate()
        {
            return new MethodStatus<bool>
            {
                Data = true
            };
        }

        public RecordSizeCategory RecordSizeCategory { get; set; } = RecordSizeCategory.All;

        //private IQueryable<TEntity> FilterByFilterExpression(IQueryable<TEntity> query, FilterExpression expression)
        //{
        //    if (expression.GetPropertyInfo(this.GetType()) != null)
        //    {
        //        query = query.FilterByProperty(expression.GetPropertyInfo(this.GetType()), expression.GetValue(this.GetType()));
        //    }
        //    if (expression.Filters != null && expression.Filters.Any())
        //    {
        //        query = expression.Filters.Aggregate(query, this.FilterByFilterExpression);
        //    }
        //    return query;
        //}

        private Type FindMappingType()
        {
            var type = typeof(IObjectMap<>).MakeGenericType(typeof(TEntity));
            var types = this.GetType().Assembly.GetTypes()
                .Where(type.IsAssignableFrom).ToList();

            if (types.Any())
            {
                return types.First();
            }
            return null;
        }

        private string GetEntityPropertyName(string clientProperty)
        {
            var entityProperty = "";
            var propertyInfo = this.FindMappingType().GetProperty(clientProperty) ?? this.GetType().GetProperty(clientProperty);
            if (propertyInfo != null)
            {
                var mappingData = propertyInfo.GetMappingPropertyAttribute();
                if (mappingData != null && mappingData.PropertyNames.Count > 0)
                {
                    entityProperty = mappingData.PropertyNames[0];
                }
            }
            return entityProperty;
        }
    }
}