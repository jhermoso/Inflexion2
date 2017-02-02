//----------------------------------------------------------------------------------------------
// <copyright file="AuditFlushEntityEventListener.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using NHibernate;
    using NHibernate.Event;
    using NHibernate.Event.Default;
    using NHibernate.Persister.Entity;

    /// <summary>
    /// http://stackoverflow.com/questions/5087888/ipreupdateeventlistener-and-dynamic-update-true
    /// </summary>
    public class AuditFlushEntityEventListener<TIdentifier> : DefaultFlushEntityEventListener
        where TIdentifier : IEquatable<TIdentifier>, IComparable<TIdentifier>
    {
        /// <summary>
        /// modification check
        /// </summary>
        /// <param name="event"></param>
        protected override void DirtyCheck(FlushEntityEvent @event)
        {
            base.DirtyCheck(@event);
            if (@event.DirtyProperties != null &&
                @event.DirtyProperties.Any() &&
                @event.Entity is IAuditableEntity<TIdentifier>)  
            {
                @event.DirtyProperties = @event.DirtyProperties.Concat(_GetAdditionalDirtyProperties(@event)).ToArray();
            }
        }

        private static IEnumerable<int> _GetAdditionalDirtyProperties(FlushEntityEvent @event)
        {
            yield return Array.IndexOf(
                             @event.EntityEntry.Persister.PropertyNames,
                             "UpdatedAt");
            yield return Array.IndexOf(
                             @event.EntityEntry.Persister.PropertyNames,
                             "UpdatedBy");
            yield return Array.IndexOf(
                             @event.EntityEntry.Persister.PropertyNames,
                             "CreatedBy");
            yield return Array.IndexOf(
                             @event.EntityEntry.Persister.PropertyNames,
                             "CreatedAt");
        }
    }
}