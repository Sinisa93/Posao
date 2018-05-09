using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Argosy.BusinessLogic.FrontEnd.Interfaces;
using Argosy.Common.Attributes;
using Argosy.Common.Enums;
//using Argosy.Common.Serialization;
//using Postal;
//using ServiceStack.DataAnnotations;
//using PropertyInfoExtensions = Argosy.Common.Extensions.PropertyInfoExtensions;
//using TypeExtensions = Argosy.Common.Extensions.TypeExtensions;

namespace Argosy.BusinessLogic.Extensions
{
    public static class ObjectExtensions
    {
        //public static String nameof<T>(Expression<Func<T>> accessor)
        //{
        //    return nameof(accessor.Body);
        //}

        //public static String nameof<T, TT>(this T obj, Expression<Func<T, TT>> propertyAccessor)
        //{
        //    return nameof(propertyAccessor.Body);
        //}

        //public static string Serialize(this object item)
        //{
        //    return SerializerFactory.GetSerializer().Serialize(item);
        //}

        //private static string nameof(Expression expression)
        //{
        //    if (expression.NodeType == ExpressionType.MemberAccess)
        //    {
        //        var memberExpression = expression as MemberExpression;
        //        return memberExpression?.Member.Name;
        //    }
        //    return null;
        //}
        //public static List<KeyValuePair<string, string>> ToKeyValuePair(this StringDictionary dictionary)
        //{
        //    return (from string item in dictionary.Keys select new KeyValuePair<string, string>(item, dictionary[item])).ToList();
        //}

        //public static bool PropertyExists(this Email item, string propertyName)
        //{
        //    return item.GetDynamicMemberNames().Any(m => m == propertyName);
        //}

        //public static List<TDest> FromMappedModelList<TSource, TDest>(this List<TSource> sourceObject)
        //{
        //    return sourceObject.Select(source => source.FromMappedModel<TSource, TDest>()).ToList();
        //}

        //public static TDest FromMappedModel<TSource, TDest>(this TSource sourceObject, ISearchObject<TSource> search = null)
        //{
        //    var sourceType = typeof(TSource);
        //    var destinationType = typeof(TDest);
        //    var destinationObject = Activator.CreateInstance<TDest>();

        //    foreach (var sourcePropertyInfo in sourceType.GetProperties())
        //    {
        //        var mappingAttribute = PropertyInfoExtensions.GetMappingPropertyAttribute(sourcePropertyInfo);
        //        var directionAttribute = PropertyInfoExtensions.GetMappingDirection(sourcePropertyInfo);
        //        if (directionAttribute.IsMappingAllowed(MappingDirection.ToDatabase) && mappingAttribute != null && (mappingAttribute.ObjectType == destinationType || mappingAttribute.IsMethodMap() && mappingAttribute.HasDestinationGetMethod()))
        //        {
        //            if (!mappingAttribute.IsMethodMap() && mappingAttribute.PropertyNames.Count > 0)
        //            {
        //                destinationObject.SetPropertyValue(mappingAttribute.PropertyNames[0], sourcePropertyInfo.GetValue(sourceObject), PropertyInfoExtensions.GetDefaultValue(sourcePropertyInfo));
        //            }
        //            else if (mappingAttribute.HasDestinationGetMethod())
        //            {
        //                object val;
        //                if (mappingAttribute.DestinationGetMethod.GetParameters().First().ParameterType == ObjectContext.GetObjectType(sourceObject.GetType()))
        //                {
        //                    val = mappingAttribute.DestinationGetMethod.Invoke(destinationObject, new object[] {
        //                                                                                                        sourceObject
        //                                                                                                    });
        //                }
        //                else
        //                {
        //                    val = mappingAttribute.DestinationGetMethod.Invoke(destinationObject, new object[] {
        //                                                                                                        sourcePropertyInfo.GetValue(sourceObject)
        //                                                                                                    });
        //                }

        //                destinationObject.SetPropertyValue(mappingAttribute.PropertyNames[0], val, PropertyInfoExtensions.GetDefaultValue(sourcePropertyInfo));
        //            }
        //        }
        //    }
        //    return destinationObject;
        //}

        //public static List<TDest> ToMappedModelList<TSource, TDest>(this List<TSource> sourceObject)
        //{
        //    return sourceObject.Select(source => source.ToMappedModel<TSource, TDest>()).ToList();
        //}

        //public static void MergeMappedModel<TSource, TDest>(this TSource sourceObject, TDest destinationObject)
        //{
        //    var sourceType = typeof(TSource);
        //    var destinationType = typeof(TDest);

        //    foreach (var sourcePropertyInfo in sourceType.GetProperties())
        //    {
        //        var mappingAttribute = PropertyInfoExtensions.GetMappingPropertyAttribute(sourcePropertyInfo);
        //        var directionAttribute = PropertyInfoExtensions.GetMappingDirection(sourcePropertyInfo);

        //        if (directionAttribute.IsMappingAllowed(MappingDirection.ToDatabase) && mappingAttribute != null && (mappingAttribute.ObjectType == destinationType || mappingAttribute.IsMethodMap() && mappingAttribute.HasDestinationGetMethod()))
        //        {
        //            if (!mappingAttribute.IsMethodMap() && mappingAttribute.PropertyNames.Count > 0)
        //            {
        //                destinationObject.SetPropertyValue(mappingAttribute.PropertyNames[0], sourcePropertyInfo.GetValue(sourceObject), PropertyInfoExtensions.GetDefaultValue(sourcePropertyInfo));
        //            }
        //            else if (mappingAttribute.HasDestinationGetMethod())
        //            {
        //                object val;
        //                if (mappingAttribute.DestinationGetMethod.GetParameters().First().ParameterType == ObjectContext.GetObjectType(sourceObject.GetType()))
        //                {
        //                    val = mappingAttribute.DestinationGetMethod.Invoke(destinationObject, new object[] {
        //                                                                                                        sourceObject
        //                                                                                                    });
        //                }
        //                else
        //                {
        //                    val = mappingAttribute.DestinationGetMethod.Invoke(destinationObject, new object[] {
        //                                                                                                        sourcePropertyInfo.GetValue(sourceObject)
        //                                                                                                    });
        //                }
        //                destinationObject.SetPropertyValue(mappingAttribute.PropertyNames[0], val, PropertyInfoExtensions.GetDefaultValue(sourcePropertyInfo));
        //            }
        //        }
        //    }
        //}

        //public static TDest ToMappedModel<TSource, TDest>(this TSource sourceObject, ISearchObject<TSource> search = null, RecordSizeCategory size = RecordSizeCategory.All)
        //{
        //    var sourceType = typeof(TSource);
        //    var destinationType = typeof(TDest);
        //    var destinationObject = Activator.CreateInstance<TDest>();

        //    foreach (var destinationPropertyInfo in destinationType.GetProperties())
        //    {
        //        try
        //        {
        //            var mappingAttribute = PropertyInfoExtensions.GetMappingPropertyAttribute(destinationPropertyInfo);
        //            var directionAttribute = PropertyInfoExtensions.GetMappingDirection(destinationPropertyInfo);
        //            var sizeCateogryAttribute = PropertyInfoExtensions.GetRecordSizeCategoryAttribute(destinationPropertyInfo);
        //            if (sizeCateogryAttribute.IsMappingAllowed(size) && directionAttribute.IsMappingAllowed(MappingDirection.FromDatabase) && mappingAttribute != null &&
        //                (mappingAttribute.ObjectType == sourceType || mappingAttribute.IsMethodMap() && mappingAttribute.HasDestinationGetMethod()))
        //            {
        //                object val;
        //                if (!mappingAttribute.IsMethodMap() && mappingAttribute.PropertyNames.Count > 0)
        //                {
        //                    sourceObject.GetPropertyValue(mappingAttribute.PropertyNames[0], destinationPropertyInfo.PropertyType, out val);
        //                    if (val != null)
        //                    {
        //                        destinationPropertyInfo.GetSetMethod().Invoke(destinationObject, new object[] {
        //                                                                                                          val
        //                                                                                                      });
        //                    }
        //                }
        //                else if (mappingAttribute.HasSourceGetMethod())
        //                {
        //                    var parameters = mappingAttribute.SourceGetMethod.GetParameters();
        //                    var paramterType = ObjectContext.GetObjectType(sourceObject.GetType());
        //                    if (parameters.First().ParameterType == paramterType)
        //                    {
        //                        if (search != null && parameters.Count() > 1 && parameters[1].ParameterType == ObjectContext.GetObjectType(search.GetType()))
        //                        {
        //                            val = mappingAttribute.SourceGetMethod.Invoke(destinationObject, new object[] {
        //                                sourceObject,
        //                                search
        //                            });
        //                        }
        //                        else
        //                        {
        //                            var paramArray = new List<object> { sourceObject };
        //                            var methodParams = mappingAttribute.SourceGetMethod.GetParameters();
        //                            paramArray.AddRange(from parameterInfo in methodParams where parameterInfo.ParameterType != paramterType && parameterInfo.IsOptional select Type.Missing);
        //                            val = mappingAttribute.SourceGetMethod.Invoke(destinationObject, paramArray.ToArray());
        //                        }
        //                        destinationPropertyInfo.GetSetMethod().Invoke(destinationObject, new object[] {
        //                                                                                                          val
        //                                                                                                      });
        //                    }
        //                    else if (mappingAttribute.PropertyNames.Any())
        //                    {
        //                        sourceObject.GetPropertyValue(mappingAttribute.PropertyNames[0], destinationPropertyInfo.PropertyType, out val);
        //                        var paramArray = new List<object> { val };
        //                        var methodParams = mappingAttribute.SourceGetMethod.GetParameters();
        //                        paramArray.AddRange(from parameterInfo in methodParams where parameterInfo.ParameterType != paramterType && parameterInfo.IsOptional select Type.Missing);
        //                        val = mappingAttribute.SourceGetMethod.Invoke(destinationObject, paramArray.ToArray());
        //                        destinationPropertyInfo.GetSetMethod().Invoke(destinationObject, new object[] {
        //                                                                                                          val
        //                                                                                                      });
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception err)
        //        {
        //            throw new Exception("There was an error mapping " + destinationPropertyInfo.Name, err);
        //        }
        //    }

        //    return destinationObject;
        //}

        public static DefaultSortAttribute GetDefaultSortAttribute(this object obj)
        {
            var attributes = obj.GetType().GetCustomAttributes(typeof(DefaultSortAttribute), false);
            if (attributes.Length > 0)
            {
                var attribute = attributes[0] as DefaultSortAttribute;
                return attribute;
            }
            return null;
        }

        //public static PropertyInfo GetPrimaryKeyProperty(this object obj)
        //{
        //    var prop = (from property in obj.GetType().GetProperties() let attributes = property.GetCustomAttributes(typeof(PrimaryKeyAttribute), false) where attributes.Length > 0 select property).FirstOrDefault();
        //    if (prop == null)
        //    {
        //        prop = (from property in obj.GetType().GetProperties() where property.Name.Equals("Id", StringComparison.InvariantCultureIgnoreCase) select property).FirstOrDefault();
        //    }
        //    return prop;
        //}

        //public static PropertyInfo GetPropertyValue(this object t, string propertyName, Type type, out object value)
        //{
        //    value = null;
        //    if (t != null)
        //    {
        //        if (TypeExtensions.IsEnumerable(t.GetType()) && ((IEnumerable<object>)t).Any())
        //        {
        //            GetPropertyValue(((IEnumerable<object>)t).First(), propertyName, type, out value);
        //        }
        //        else if (!TypeExtensions.IsEnumerable(t.GetType()))
        //        {
        //            if (t.GetType().GetProperties().Count(p => p.Name == propertyName.Split('.')[0]) == 0)
        //                return null;
        //            if (propertyName.Split('.').Length == 1)
        //            {
        //                var value1 = t.GetType().GetProperty(propertyName).GetValue(t, null);
        //                value = value1;
        //                return t.GetType().GetProperty(propertyName);
        //            }
        //            else
        //            {
        //                return GetPropertyValue(t.GetType().GetProperty(propertyName.Split('.')[0]).GetValue(t, null), propertyName.Substring(propertyName.IndexOf('.') + 1, propertyName.Length - propertyName.IndexOf('.') - 1), type,
        //                    out value);
        //            }
        //        }
        //    }
        //    return null;
        //}

        //public static void SetPropertyValue(this object t, string propertName, object value, object defaultValue)
        //{
        //    if (t != null)
        //    {
        //        try
        //        {
        //            if (propertName.Split('.').Length == 1)
        //            {
        //                t.GetType().GetProperty(propertName).SetValue(t, value ?? defaultValue);
        //            }
        //            else
        //            {
        //                var propertyInfo = t.GetType().GetProperty(propertName.Split('.')[0]);
        //                SetPropertyValue(propertyInfo.GetValue(t, null), propertName.Substring(propertName.IndexOf('.') + 1, propertName.Length - propertName.IndexOf('.') - 1), value, PropertyInfoExtensions.GetDefaultValue(propertyInfo));
        //            }
        //        }
        //        catch (Exception err)
        //        {
        //            throw new Exception("Could not map " + propertName + " with value " + (value ?? "null") + " for " + t.GetType().Name, err);
        //        }
        //    }
        //}

        public static IEnumerable<T> IntersectNonEmpty<T>(this IEnumerable<IEnumerable<T>> lists)
        {
            var nonEmptyLists = lists.Where(l => l.Any<T>());
            return nonEmptyLists.Aggregate((l1, l2) => l1.Intersect<T>(l2));
        }

        public static List<T> ToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                var list = new List<T>();
                foreach (var row in table.AsEnumerable())
                {
                    var obj = new T();
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            var propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}
