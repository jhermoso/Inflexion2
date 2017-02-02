namespace Inflexion2.Domain
{
    using System;

    /// <summary>
    /// poc for CQRS implementation 
    /// repository iplementation for Event Sourced Entities 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventSourcedRepository<T> : IEventSourcedRepository<T>
        where T : EventSourcedEntity, new()
    {
        private readonly IEventStore storage;

        /// <summary>
        /// constructor ann initialization of the repository for the related Event Sourced Entity
        /// </summary>
        /// <param name="storage"></param>
        public EventSourcedRepository(IEventStore storage)
        {
            this.storage = storage;
        }

        /// <summary>
        /// get by id the Event Sourced Entity
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T GetById(Guid Id)
        {
            var obj = new T();
            var e = this.storage.GetEventsForAggregate(Id);
            obj.LoadsFromHistory(e);
            return obj;
        }

        /// <summary>
        /// save the Event Sourced Entity
        /// </summary>
        /// <param name="aggregate"></param>
        /// <param name="expectedVersion"></param>
        public void Save(EventSourcedEntity aggregate, int expectedVersion)
        {
            this.storage.SaveEvents(aggregate.Id, aggregate.GetUncommittedChanges(), expectedVersion);
        }
    }
}