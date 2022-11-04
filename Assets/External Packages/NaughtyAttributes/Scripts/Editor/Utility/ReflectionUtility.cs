using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace NaughtyAttributes.Editor
{
    public static class ReflectionUtility
    {
        private const BindingFlags DeclaredOnly = BindingFlags.Instance | BindingFlags.Static
            | BindingFlags.NonPublic | BindingFlags.Public
            | BindingFlags.DeclaredOnly;


        #region Get All Type elements

        public static IEnumerable<FieldInfo> GetAllFields(object target, Func<FieldInfo, bool> predicate)
        {
            if (target == null)
            {
                Debug.LogError("The target object is null. Check for missing scripts.");
                yield break;
            }

            var types = GetSelfAndBaseTypes(target);

            for (int i = types.Count - 1; i >= 0; i--)
            {
                var fieldInfos = types[i].GetFields(DeclaredOnly).Where(predicate);

                foreach (var fieldInfo in fieldInfos)
                {
                    yield return fieldInfo;
                }
            }
        }

        public static IEnumerable<PropertyInfo> GetAllProperties(object target, Func<PropertyInfo, bool> predicate)
        {
            if (target == null)
            {
                Debug.LogError("The target object is null. Check for missing scripts.");
                yield break;
            }

            var types = GetSelfAndBaseTypes(target);

            for (int i = types.Count - 1; i >= 0; i--)
            {
                var propertyInfos = types[i].GetProperties(DeclaredOnly).Where(predicate);

                foreach (var propertyInfo in propertyInfos)
                {
                    yield return propertyInfo;
                }
            }
        }

        public static IEnumerable<MethodInfo> GetAllMethods(object target, Func<MethodInfo, bool> predicate)
        {
            if (target == null)
            {
                Debug.LogError("The target object is null. Check for missing scripts.");
                yield break;
            }

            var types = GetSelfAndBaseTypes(target);

            for (int i = types.Count - 1; i >= 0; i--)
            {
                var methodInfos = types[i].GetMethods(DeclaredOnly).Where(predicate);

                foreach (var methodInfo in methodInfos)
                {
                    yield return methodInfo;
                }
            }
        }

        #endregion


        #region Get Single Type element

        public static FieldInfo GetField(object target, string fieldName)
        {
            return GetFirstField(GetSelfAndBaseTypes(target), f => f.Name.Equals(fieldName, StringComparison.Ordinal));
        }

        public static FieldInfo GetField(IReadOnlyList<Type> targetTypes, string fieldName)
        {
            return GetFirstField(targetTypes, f => f.Name.Equals(fieldName, StringComparison.Ordinal));
        }

        [CanBeNull]
        private static FieldInfo GetFirstField(IReadOnlyList<Type> types, Func<FieldInfo, bool> predicate)
        {
            if (types == null || types.Count == 0)
            {
                Debug.LogError("The target object is null. Check for missing scripts.");
                return null;
            }

            for (int i = types.Count - 1; i >= 0; i--)
            {
                foreach (var fieldInfo in types[i].GetFields(DeclaredOnly))
                {
                    if (predicate(fieldInfo))
                    {
                        return fieldInfo;
                    }
                }
            }
            return null;
        }


        public static PropertyInfo GetProperty(object target, string propertyName)
        {
            return GetFirstProperty(
                GetSelfAndBaseTypes(target), p => p.Name.Equals(propertyName, StringComparison.Ordinal)
            );
        }

        public static PropertyInfo GetProperty(IReadOnlyList<Type> targetTypes, string propertyName)
        {
            return GetFirstProperty(targetTypes, p => p.Name.Equals(propertyName, StringComparison.Ordinal));
        }

        [CanBeNull]
        private static PropertyInfo GetFirstProperty(IReadOnlyList<Type> types, Func<PropertyInfo, bool> predicate)
        {
            if (types == null || types.Count == 0)
            {
                Debug.LogError("The target object is null. Check for missing scripts.");
                return null;
            }

            for (int i = types.Count - 1; i >= 0; i--)
            {
                foreach (var property in types[i].GetProperties(DeclaredOnly))
                {
                    if (predicate(property))
                    {
                        return property;
                    }
                }
            }

            return null;
        }

        public static MethodInfo GetMethod(object target, string methodName)
        {
            return GetFirstMethod(
                GetSelfAndBaseTypes(target), m => m.Name.Equals(methodName, StringComparison.Ordinal)
            );
        }

        public static MethodInfo GetMethod(IReadOnlyList<Type> targetTypes, string methodName)
        {
            return GetFirstMethod(targetTypes, m => m.Name.Equals(methodName, StringComparison.Ordinal));
        }

        [CanBeNull]
        public static MethodInfo GetFirstMethod(IReadOnlyList<Type> types, Func<MethodInfo, bool> predicate)
        {
            if (types == null || types.Count == 0)
            {
                Debug.LogError("The target object is null. Check for missing scripts.");
                return null;
            }

            for (int i = types.Count - 1; i >= 0; i--)
            {
                foreach (var method in types[i].GetMethods(DeclaredOnly))
                {
                    if (predicate(method))
                    {
                        return method;
                    }
                }
            }

            return null;
        }

        #endregion


        public static Type GetListElementType(Type listType)
        {
            if (listType.IsGenericType)
            {
                return listType.GetGenericArguments()[0];
            }

            return listType.GetElementType();
        }

        /// <summary>
        ///		Get type and all base types of target, sorted as following:
        ///		<para />[target's type, base type, base's base type, ...]
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IReadOnlyList<Type> GetSelfAndBaseTypes(object target)
        {
            var types = new List<Type>(4) {target.GetType(),};

            Type lastType;
            while ((lastType = types.Last()).BaseType != null)
            {
                types.Add(lastType.BaseType);
            }

            return types;
        }
    }
}
