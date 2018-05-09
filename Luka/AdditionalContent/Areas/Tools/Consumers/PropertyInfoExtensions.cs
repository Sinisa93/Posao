using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Argosy.Common.Attributes;
//using DocumentFormat.OpenXml.Office2010.ExcelAc;

namespace Argosy.Common.Extensions {
    public static class PropertyInfoExtensions {
        public static MappingPropertyAttribute GetMappingPropertyAttribute(this PropertyInfo property) {
            var attributes = property.GetCustomAttributes(typeof(MappingPropertyAttribute), false);
            if (attributes.Length > 0) {
                var attribute = attributes[0] as MappingPropertyAttribute;
                return attribute;
            }
            return null;
        }
        //public static ExclusionPropertyAttribute GetExclusionPropertyAttribute(this PropertyInfo property) {
        //    var attributes = property.GetCustomAttributes(typeof(ExclusionPropertyAttribute), false);
        //    if (attributes.Length > 0) {
        //        var attribute = attributes[0] as ExclusionPropertyAttribute;
        //        return attribute;
        //    }
        //    return null;
        //}
        //public static ContainsPropertyAttribute GetContainsPropertyAttribute(this PropertyInfo property) {
        //    var attributes = property.GetCustomAttributes(typeof(ContainsPropertyAttribute), false);
        //    if (attributes.Length > 0) {
        //        var attribute = attributes[0] as ContainsPropertyAttribute;
        //        return attribute;
        //    }
        //    return null;
        //}
        //public static IgnorePropertyAttribute GetIgnoreProperty(this PropertyInfo property) {
        //    var attributes = property.GetCustomAttributes(typeof(IgnorePropertyAttribute), false);
        //    if (attributes.Length > 0) {
        //        var attribute = attributes[0] as IgnorePropertyAttribute;
        //        return attribute;
        //    } else {
        //        return new IgnorePropertyAttribute();
        //    }
        //}
        public static object GetDefaultValue(this PropertyInfo property) {
            var attributes = property.GetCustomAttributes(typeof(DefaultValueAttribute), false);
            if (attributes.Length > 0) {
                var attribute = attributes[0] as DefaultValueAttribute;
                var t = property.PropertyType;
                if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof (Nullable<>)) {
                    t = Nullable.GetUnderlyingType(t);
                }
                return Convert.ChangeType(attribute.Value, t);
            } else {
                return new DefaultValueAttribute(property.GetType(), "").Value;
            }
        }
        //public static EqualityAttribute GetEqualityProperty(this PropertyInfo property) {
        //    var attributes = property.GetCustomAttributes(typeof(EqualityAttribute), false);
        //    if (attributes.Length > 0) {
        //        var attribute = attributes[0] as EqualityAttribute;
        //        return attribute;
        //    } else {
        //        return new EqualityAttribute();
        //    }
        //}
        
        //public static RecordSizeCategoryAttribute GetRecordSizeCategoryAttribute(this PropertyInfo property)
        //{
        //    var attributes = property.GetCustomAttributes(typeof(RecordSizeCategoryAttribute), false);
        //    if (attributes.Length > 0)
        //    {
        //        var attribute = attributes[0] as RecordSizeCategoryAttribute;
        //        return attribute;
        //    }
        //    else {
        //        return new RecordSizeCategoryAttribute();
        //    }
        //}
        //public static MappingDirectionAttribute GetMappingDirection(this PropertyInfo property) {
        //    var attributes = property.GetCustomAttributes(typeof(MappingDirectionAttribute), false);
        //    if (attributes.Length > 0) {
        //        var attribute = attributes[0] as MappingDirectionAttribute;
        //        return attribute;
        //    } else {
        //        return new MappingDirectionAttribute();
        //    }
        //}

        public static List<PropertyInfo> GetMappingPropertyInfo(this MappingPropertyAttribute attribute) {
            return attribute.PropertyNames.Select(propertyName => attribute.ObjectType.GetProperty(propertyName)).ToList();
        }

        public static bool IsRequired(this PropertyInfo property) {
            var attributes = property.GetCustomAttributes(typeof(RequiredAttribute), false);
            return attributes.Length > 0;
        }
    }
}
