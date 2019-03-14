//----------------------------------------------------------------------------------------------
// <copyright file="EntityMap.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using NHibernate.Dialect;

    /// <summary>
    /// map entity class
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class EntityMap<TEntity, TKey> : BaseClassMap<TEntity>
        where TEntity : Entity<TEntity, TKey>
        where TKey : struct, IEquatable<TKey>, IComparable<TKey>
    {
        /// <summary>
        /// base mapper constructor
        /// </summary>
        public EntityMap()
        {
            if (typeof(TKey).Equals(typeof(int)))
            {
                this.Id(x => x.Id)
                    .UnsavedValue(0)
                    .GeneratedBy.Native();
            }

            if (typeof(TKey).Equals(typeof(Guid)))
            {
                this.Id(x => x.Id)
                    .GeneratedBy.GuidComb();
            }

            // Use versioned timestamp as optimistick lock mechanism.
            this.OptimisticLock.Version();

            // Create Insert statements dynamically.
            this.DynamicInsert();

            // Create Update statements dynamically.
            this.DynamicUpdate();

            //this.Version(x => x.Version)
            //    .CustomType<TicksAsString>();
        }
    }
}