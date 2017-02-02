//----------------------------------------------------------------------------------------------
// <copyright file="NotNullable.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    /// <summary>
    /// convention for not nullable atributte
    /// </summary>
    public class NotNullable : IPropertyConvention
    {
        /// <summary>
        /// apply convention for not nullable atributte
        /// </summary>
        /// <param name="target"></param>
        public void Apply(IPropertyInstance target)
        {
            var attribute =
                Attribute.GetCustomAttribute(target.Property.MemberInfo, typeof(RequiredAttribute)) as
                RequiredAttribute;

            if (attribute != null)
            {
                target.Not.Nullable();
            }
        }
    }
}