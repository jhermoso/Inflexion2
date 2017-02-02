namespace Inflexion2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// poc for CQRS implementation 
    /// event store implementation
    /// </summary>
    public abstract class BaseEventStore : IEventStore
    {
        private readonly IEventPublisher publisher;

        /// <summary>
        /// event store constructor and inizialitation
        /// </summary>
        /// <param name="publisher"></param>
        protected BaseEventStore(IEventPublisher publisher)
        {
            this.publisher = publisher;
        }

        /// <summary>
        /// get events of one entity (root agregate)
        /// </summary>
        /// <param name="aggregateId"></param>
        /// <returns></returns>
        public List<Event> GetEventsForAggregate(Guid aggregateId)
        {
            IEnumerable<EventDescriptor> eventDescriptors = this.LoadEventDescriptorsForAggregate(aggregateId);
            if (null == eventDescriptors || !eventDescriptors.Any())
            {
                throw new AggregateNotFoundException();
            }

            return eventDescriptors.Select(desc => desc.EventData).ToList();
        }

        /// <summary>
        /// save events of one aggregate
        /// </summary>
        /// <param name="aggregateId"></param>
        /// <param name="events"></param>
        /// <param name="expectedVersion"></param>
        public void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion)
        {
            var eventDescriptors = new List<EventDescriptor>();
            var i = expectedVersion;
            foreach (var @event in events)
            {
                i++;
                @event.Version = i;
                eventDescriptors.Add(new EventDescriptor(aggregateId, @event, i));
            }

            this.PersistEventDescriptors(eventDescriptors, aggregateId, expectedVersion);

            MethodInfo publishMethod = this.publisher.GetType().GetMethod("Publish");

            foreach (Event @event in events)
            {
                MethodInfo method = publishMethod.MakeGenericMethod(new Type[] { @event.GetType() });
                method.Invoke(this.publisher, new object[] { @event });

                // _publisher.Publish(@event);
            }
        }

        /// <summary>
        /// abstract method to load event descriptor of one entity (R. aggregate)
        /// </summary>
        /// <param name="aggregateId"></param>
        /// <returns></returns>
        protected abstract IEnumerable<EventDescriptor> LoadEventDescriptorsForAggregate(Guid aggregateId);

        /// <summary>
        /// abstract save descriptor
        /// </summary>
        /// <param name="newEventDescriptors"></param>
        /// <param name="aggregateId"></param>
        /// <param name="expectedVersion"></param>
        protected abstract void PersistEventDescriptors(IEnumerable<EventDescriptor> newEventDescriptors, Guid aggregateId, int expectedVersion);
    }
}