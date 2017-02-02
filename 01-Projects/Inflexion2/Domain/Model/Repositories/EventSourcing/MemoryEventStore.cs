//----------------------------------------------------------------------------------------------
// <copyright file="MemoryEventStore.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc.  All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// poc for CQRS implementation 
    /// final event store implementation 
    /// </summary>
    public class MemoryEventStore : BaseEventStore
    {
        private readonly Dictionary<Guid, List<EventDescriptor>> current = new Dictionary<Guid, List<EventDescriptor>>();

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="publisher"></param>
        public MemoryEventStore(IEventPublisher publisher)
        : base(publisher)
        {
        }

        /// <summary>
        /// get the vents for one entity
        /// </summary>
        /// <param name="aggregateId"></param>
        /// <returns></returns>
        protected override IEnumerable<EventDescriptor> LoadEventDescriptorsForAggregate(Guid aggregateId)
        {
            if (!this.current.ContainsKey(aggregateId))
            {
                return new EventDescriptor[] { };
            }

            return this.current[aggregateId];
        }

        /// <summary>
        /// save the events for one entity
        /// </summary>
        /// <param name="newEventDescriptors"></param>
        /// <param name="aggregateId"></param>
        /// <param name="expectedVersion"></param>
        protected override void PersistEventDescriptors(IEnumerable<EventDescriptor> newEventDescriptors, Guid aggregateId, int expectedVersion)
        {
            List<EventDescriptor> eventDescriptors;
            if (!this.current.TryGetValue(aggregateId, out eventDescriptors))
            {
                eventDescriptors = new List<EventDescriptor>();
                this.current.Add(aggregateId, eventDescriptors);
            }
            else if (eventDescriptors[eventDescriptors.Count - 1].Version != expectedVersion && expectedVersion != -1)
            {
                throw new ConcurrencyException();
            }

            eventDescriptors.AddRange(newEventDescriptors);
        }
    }
}