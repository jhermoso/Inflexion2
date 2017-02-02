//----------------------------------------------------------------------------------------------
// <copyright file="StringLengthConvention.cs" company="HexaSystems Inc">
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
    /// convention for string lenght attributte
    /// </summary>
    public class StringLengthConvention : IPropertyConvention
    {
        /// <summary>
        /// applies convention for string lenght attributte
        /// </summary>
        /// <param name="target"></param>
        public void Apply(IPropertyInstance target)
        {
            var attribute =
                Attribute.GetCustomAttribute(target.Property.MemberInfo, typeof(StringLengthAttribute)) as
                StringLengthAttribute;

            if (attribute != null)
            {
                target.Length(attribute.MaximumLength);
            }
        }
    }
}