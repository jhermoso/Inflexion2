//----------------------------------------------------------------------------------------------
// <copyright file="EventSourcedEntity.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using Inflexion2.DynamicExtensions;

    /// <summary>
    ///  poc for CQRS implementation 
    /// </summary>
    [Serializable]
    public class Event
    {
        /// <summary>
        /// event version
        /// </summary>
        public int Version
        {
            get;
            set;
        }
    }

    /// <summary>
    /// event source entity to save historic changes
    /// </summary>
    public abstract class EventSourcedEntity
    {
        private readonly List<Event> _changes = new List<Event>();

        /// <summary>
        /// entity identifier
        /// </summary>
        public Guid Id
        {
            get;
            protected set;
        }

        /// <summary>
        /// TODO: update comments
        /// </summary>
        public int Version
        {
            get;
            internal set;
        }

        /// <summary>
        /// TODO: update comments
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Event> GetUncommittedChanges()
        {
            return this._changes;
        }

        /// <summary>
        /// TODO: update comments
        /// </summary>
        /// <param name="history"></param>
        public void LoadsFromHistory(IEnumerable<Event> history)
        {
            foreach (var e in history)
            {
                this.ApplyChange(e, false);
                this.Version = e.Version;
            }
        }

        /// <summary>
        /// TODO: update comments
        /// </summary>
        public void MarkChangesAsCommitted()
        {
            this._changes.Clear();
        }

        /// <summary>
        /// TODO: update comments
        /// </summary>
        /// <param name="event"></param>
        protected void ApplyChange(Event @event)
        {
            this.ApplyChange(@event, true);
        }

        private void ApplyChange(Event @event, bool isNew)
        {
            this.AsDynamic().Apply(@event);
            if (isNew)
            {
                this._changes.Add(@event);
            }
        }
    }
}