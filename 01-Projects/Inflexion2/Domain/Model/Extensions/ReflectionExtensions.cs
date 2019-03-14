//----------------------------------------------------------------------------------------------
// <copyright file="ReflectionExtensions.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------

namespace Inflexion2
{
    using System;
    using System.Collections;
    using System.Reflection;

    /// <summary>
    /// .es extensiones de reflexión. 
    /// .en Reflexion Extensions
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// nos indica si el tipo que pasamos deriva de un tipo generico que pasamos como segundo parametro
        /// </summary>
        /// <param name="source">type to evaluate</param>
        /// <param name="generic">the generic type</param>
        /// <returns></returns>
        public static bool IsSubclassOfGeneric(this Type source, Type generic)
        {
            while (source != null && source != typeof(object))
            {
                Type cur = source.IsGenericType ? source.GetGenericTypeDefinition() : source;
                if (generic == cur)
                {
                    return true;
                }

                source = source.BaseType;
            }

            return false;
        }

        /// <summary>
        /// TODO: update comments
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public static bool IsNonStringEnumerable(this PropertyInfo pi)
        {
            return pi != null && pi.PropertyType.IsNonStringEnumerable();
        }

        /// <summary>
        /// TODO: update comments
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static bool IsNonStringEnumerable(this object instance)
        {
            return instance != null && instance.GetType().IsNonStringEnumerable();
        }

        /// <summary>
        /// TODO: update comments
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNonStringEnumerable(this Type type)
        {
            if (type == null || type == typeof(string))
                return false;
            return typeof(IEnumerable).IsAssignableFrom(type);
        }
    }
}