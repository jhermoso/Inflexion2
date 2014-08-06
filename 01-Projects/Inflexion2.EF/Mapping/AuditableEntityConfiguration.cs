//----------------------------------------------------------------------------------------------
// <copyright file="AuditableEntityConfiguration.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Data.Entity.ModelConfiguration;

    public class AuditableEntityConfiguration<TEntity, TIdentifier> : AuditableEntityConfiguration<TEntity, TIdentifier, string>
        where TEntity : AuditableEntity<TEntity, TIdentifier>, IEquatable<TEntity>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
    }

    public class AuditableEntityConfiguration<TEntity, TIdentifier, TUserKey> : EntityTypeConfiguration<TEntity>
        where TEntity : AuditableEntity<TEntity, TIdentifier>, IEquatable<TEntity>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>

    {
        public AuditableEntityConfiguration()
        {
            this.Property(x => x.AuditInfo.CreatedTimestamp) // CreatedAt
                .IsRequired();

            this.Property(x => x.AuditInfo.UpdatedTimestamp) // UpdatedAt
                .IsRequired();

            Type keyType = typeof(TUserKey);
            if (keyType.Equals(typeof(string)))
            {
                this.Property(x => x.AuditInfo.CreatedBy); // CreatedBy
                this.Property(x => x.AuditInfo.UpdatedBy); // UpdatedBy
            }
            else if (keyType.Equals(typeof(Guid)))
            {
                this.Property(x => x.AuditInfo.CreatedBy)
                    .HasColumnType("UniqueIdentifier");
                this.Property(x => x.AuditInfo.UpdatedBy)
                    .HasColumnType("UniqueIdentifier");
            }
            else if (keyType.Equals(typeof(int)))
            {
                this.Property(x => x.AuditInfo.CreatedBy);
                    //.HasColumnType("string");
                this.Property(x => x.AuditInfo.UpdatedBy);
                    //.HasColumnType("string");
            }

    //        this.Property(x => x.Version)
    //.IsConcurrencyToken();
        }
    }
}