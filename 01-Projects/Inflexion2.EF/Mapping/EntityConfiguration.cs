//----------------------------------------------------------------------------------------------
// <copyright file="EntityConfiguration.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class EntityConfiguration<TEntity, TIdentifier> : EntityTypeConfiguration<TEntity>
        where TEntity : Entity<TEntity, TIdentifier>, IEntity<TIdentifier> // si no usamos interfaces podemos derivar tambien de "Entity<TEntity, TIdentifier>,"
        where TIdentifier : struct, System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        public EntityConfiguration()
        {
            this.HasKey(x => x.Id);

            this.Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.ToTable(Inflector.Underscore(typeof(TEntity).Name).ToUpper(), string.Empty);
        }
    }
}