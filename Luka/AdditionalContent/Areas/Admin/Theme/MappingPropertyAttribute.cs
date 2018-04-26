using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Argosy.Common.Enums;
using Argosy.Common.Interfaces;

namespace Argosy.Common.Attributes {
    public class MappingPropertyAttribute : Attribute {
        public Type ObjectType = null;
        public Type ValueType = null;
        public List<string> PropertyNames = new List<string>();
        public MethodInfo SourceGetMethod = null;
        public MethodInfo DestinationGetMethod = null;
        public QueryMethod QueryMethod = QueryMethod.Any;

        /// <summary>
        /// Defines how to map a property to a entity framework property or any other type of object property
        /// </summary>
        /// <param name="objectType">Type this property maps too</param>
        /// <param name="propertyName">Property name this property should set</param>
        /// <param name="valueType">Type of the property this mapping represents</param>
        /// <param name="queryMethod">Type of query method to use if it's a enumerable</param>
        public MappingPropertyAttribute(Type objectType, string propertyName, Type valueType, QueryMethod queryMethod = QueryMethod.Any) {
            ObjectType = objectType;
            ValueType = valueType;
            PropertyNames.Add(propertyName);
            QueryMethod = queryMethod;
        }

        /// <summary>
        /// Defines how to map a property to a entity framework property or any other type of object property
        /// </summary>
        /// <param name="objectType">Type this property maps too</param>
        /// <param name="propertyNames">Property name this property should set</param>
        /// <param name="valueType">Type of the property this mapping represents</param>
        public MappingPropertyAttribute(Type objectType, Type valueType, params string[] propertyNames) {
            ObjectType = objectType;
            ValueType = valueType;
            if (propertyNames != null && propertyNames.Length > 0) {
                PropertyNames = propertyNames.ToList();
            }
        }

        /// <summary>
        /// Defines how to map a property to a entity framework property or any other type of object property
        /// </summary>
        /// <param name="sourceObjectType">Entity Framework type to call the get extension method on</param>
        /// <param name="propertyName">Property name this property should set</param>
        /// <param name="valueType">Type of the property this mapping represents</param>
        /// <param name="destinationValueType">Client Entity type to call the set extension method on</param>
        /// <param name="souceMethod">Method name of an extension for get the <paramref name="sourceObjectType"/> ref</param>
        /// <param name="destinationMethod">Method name of an extension for set the <paramref name="destinationValueType"/> ref</param>
        /// <param name="extensionClass">Type were the extension methods you're calling are located in</param>
        public MappingPropertyAttribute(Type sourceObjectType, Type valueType, string propertyName, string souceMethod, Type destinationValueType, string destinationMethod, Type extensionClass) {
            ObjectType = sourceObjectType;
            PropertyNames.Add(propertyName);
            ValueType = valueType;
            SourceGetMethod = ParseExtensionMethod(souceMethod, extensionClass, valueType);
            DestinationGetMethod = ParseExtensionMethod(destinationMethod, extensionClass, destinationValueType);
        }

        /// <summary>
        /// Defines how to map a property to a entity framework property or any other type of object property.
        /// This only maps one way when you use this constructor
        /// </summary>
        /// <param name="sourceObjectType">Entity Framework type to call the get extension method on</param>
        /// <param name="souceMethod">Method name of an extension for get the <paramref name="sourceObjectType"/> ref</param>
        /// <param name="extensionClass">Type were the extension methods you're calling are located in</param>
        public MappingPropertyAttribute(Type sourceObjectType, Type extensionClass, string souceMethod) {
            ObjectType = sourceObjectType;
            SourceGetMethod = ParseExtensionMethod(souceMethod, extensionClass, sourceObjectType);
        }

        private MethodInfo ParseExtensionMethod(string methodName, Type extensionClass, Type objectType) {
            var methodInfo = GetExtensionMethods(extensionClass.Assembly, objectType).Where(m => m.Name == methodName).ToList();
           if (methodInfo == null || !methodInfo.Any()) {
                throw new Exception(methodName + " cannot be located for " + ObjectType.Name);
            }
            if (methodInfo.Count > 1) {
                throw new Exception("Multiple methods named " + methodName + " for " + ObjectType.Name + " were found.  Parameter types not implemented yet, talk to andrew.");
            }
            return methodInfo.First();
        }

        private static IEnumerable<MethodInfo> GetExtensionMethods(Assembly assembly,Type extendedType) {            
            var query = from type in assembly.GetTypes()
                        where type.IsSealed && !type.IsGenericType && !type.IsNested
                        from method in type.GetMethods(BindingFlags.Static
                            | BindingFlags.Public | BindingFlags.NonPublic)
                        where method.IsDefined(typeof(ExtensionAttribute), false)
                        where method.GetParameters()[0].ParameterType == extendedType
                        select method;
            return query;
        }

        public bool IsMethodMap() {
            return DestinationGetMethod != null || SourceGetMethod != null;
        }

        public bool HasDestinationGetMethod() {
            return DestinationGetMethod != null;
        }

        public bool HasSourceGetMethod() {
            return SourceGetMethod != null;
        }

        public Type FindMappingType(Assembly assembly) {
            var type = typeof(IObjectMap<>).MakeGenericType(ObjectType);
            var types = assembly.GetTypes()
                .Where(type.IsAssignableFrom).ToList();

            if (types.Any()) {
                return types.First();
            }
            return null;
        }
    }
}