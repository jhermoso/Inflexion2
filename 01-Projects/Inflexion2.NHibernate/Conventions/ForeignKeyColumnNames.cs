//----------------------------------------------------------------------------------------------
// <copyright file="ForeignKeyColumnNames.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;

    using FluentNHibernate;
    using FluentNHibernate.Conventions;

    /// <summary>
    /// naming convention for foreign column name
    /// </summary>
    public class ForeignKeyColumnNames : ForeignKeyConvention
    {
        /// <summary>
        /// get name of key column
        /// </summary>
        /// <param name="property"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        protected override string GetKeyName(Member property, Type type)
        {
            // many-to-many, one-to-many, join
            if (property == null)
            {
                if (type.GetProperty("UniqueId") != null)
                {
                    return type.Name + "UniqueId";
                }

                return type.Name + "Id";
            }

            // else -- many-to-one
            if (property.PropertyType.GetProperty("UniqueId") != null)
            {
                return property.Name + "UniqueId";
            }

            return property.Name + "Id";
        }
    }
}