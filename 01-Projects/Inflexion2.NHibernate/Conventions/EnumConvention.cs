//----------------------------------------------------------------------------------------------
// <copyright file="EnumConvention.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.AcceptanceCriteria;
    using FluentNHibernate.Conventions.Inspections;
    using FluentNHibernate.Conventions.Instances;

    /// <summary>
    /// convention implementation
    /// https://github.com/jagregory/fluent-nhibernate/wiki/Conventions
    /// </summary>
    public class EnumConvention : IPropertyConvention, IPropertyConventionAcceptance
    {
        /// <summary>
        /// accept convention
        /// </summary>
        /// <param name="criteria"></param>
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Property.PropertyType.IsEnum);
        }

        /// <summary>
        /// apply convention
        /// </summary>
        /// <param name="instance"></param>
        public void Apply(IPropertyInstance instance)
        {
            instance.CustomType(instance.Property.PropertyType);
        }
    }
}