//----------------------------------------------------------------------------------------------
// <copyright file="ForeignKeyConstraintNames.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    /// <summary>
    /// naming convention for ForeignKey
    /// </summary>
    public class ForeignKeyConstraintNames : IReferenceConvention, IHasManyConvention
    {
        /// <summary>
        /// naming convention for one to many instance
        /// </summary>
        /// <param name="instance"></param>
        public void Apply(IOneToManyCollectionInstance instance)
        {
            string entity = instance.EntityType.Name;
            string member = instance.Member.Name;
            string child = instance.ChildType.Name;

            instance.Key.ForeignKey(string.Format("FK_{0}{1}_{2}", entity, member, child));
        }

        /// <summary>
        /// naming convention for many to one instance
        /// </summary>
        /// <param name="instance"></param>
        public void Apply(IManyToOneInstance instance)
        {
            string entity = instance.EntityType.Name;
            string member = instance.Property.Name;

            instance.ForeignKey(string.Format("FK_{0}_{1}", entity, member));
        }
    }
}