//----------------------------------------------------------------------------------------------
// <copyright file="EntityConfiguration.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Reflection.Emit;

    /// <summary>
    /// Generic Base class for configuration classes of entities in EntityFramework.
    /// </summary>
    /// <typeparam name="TValueObject"></typeparam>

    public class ValueObjectConfiguration<TValueObject> : EntityTypeConfiguration<TValueObject>
        where TValueObject : ValueObject<TValueObject>, IValueObject // si no usamos interfaces podemos derivar tambien de "Entity<TEntity, TIdentifier>,"
    {
        /// <summary>
        /// base configuration entities
        /// </summary>
        public ValueObjectConfiguration()
        {

           // this.ToTable(Inflector.Underscore(typeof(TValueObject).Name).ToUpper(), string.Empty);
        }


    }
}